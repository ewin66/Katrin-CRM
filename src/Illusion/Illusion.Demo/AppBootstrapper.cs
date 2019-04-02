namespace Illusion.Demo
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.Composition;
	using System.ComponentModel.Composition.Hosting;
	using System.ComponentModel.Composition.Primitives;
	using System.Linq;
	using Illusion;
	using System.Windows;
	using System.Reflection;

	public class AppBootstrapper : Bootstrapper<IShell>
	{
		CompositionContainer container;

		/// <summary>
		/// By default, we are configured to use MEF
		/// </summary>
		protected override void Configure()
		{
			var catalog = new AggregateCatalog(
				AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
				);

			catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory + "/AddIns"));

			container = new CompositionContainer(catalog);

			var batch = new CompositionBatch();

			var windowManager = new AvalonDockWindowManager();

			batch.AddExportedValue<IEventAggregator>(new EventAggregator());
			batch.AddExportedValue<IResourceService>(new ResourceService());
			batch.AddExportedValue<IWindowManager>(windowManager);
			batch.AddExportedValue<IDockWindowManager>(windowManager);
			batch.AddExportedValue<IConfigurationService>(new ConfigurationService(@"Configuration"));
			batch.AddExportedValue<IThemeService>(new ThemeService());
			batch.AddExportedValue<IOptionService>(new OptionService());
			batch.AddExportedValue(container);
			batch.AddExportedValue(catalog);

			container.Compose(batch);

			container.ComposeParts(container.GetExportedValue<IResourceService>());
			container.ComposeParts(container.GetExportedValue<IThemeService>());
			container.ComposeParts(container.GetExportedValue<IOptionService>());

			//Extend the name rule of ViewLocator, the rule is : LanguageOption -> LanaguageOptionView
			ViewLocator.NameTransformer.AddRule("Option$", "OptionView");
		}

		protected override IEnumerable<Assembly> SelectAssemblies()
		{
			return new Assembly[] { Assembly.GetEntryAssembly(), typeof(IPart).Assembly };
		}

		protected override void StartRuntime()
		{
			Execute.InitializeWithDispatcher();
			AssemblySource.Instance.AddRange(SelectAssemblies());

			Application = Application.Current;
			PrepareApplication();

			//Reorder to put configure at the last step.
			IoC.GetInstance = GetInstance;
			IoC.GetAllInstances = GetAllInstances;
			IoC.BuildUp = BuildUp;
			Configure();
		}

		protected override void StartDesignTime()
		{
			//Init ResourceService for design time.
			ResourceService resource = new ResourceService();
			resource.Resources = new IResource[] { new Resource() };
			IoC.GetInstance = (i, u) =>
				{
					if (i == typeof(IResourceService))
					{
						return resource;
					}
					return null;
				};
		}

		protected override object GetInstance(Type serviceType, string key)
		{
			string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
			var exports = container.GetExportedValues<object>(contract);

			if (exports.Count() > 0)
				return exports.First();

			throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
		}

		protected override IEnumerable<object> GetAllInstances(Type serviceType)
		{
			return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
		}

		protected override void BuildUp(object instance)
		{
			container.SatisfyImportsOnce(instance);
		}

		protected override void OnExit(object sender, EventArgs e)
		{
			base.OnExit(sender, e);

			IConfigurationService configService = IoC.Get<IConfigurationService>();
			configService.Save();
		}
	}
}
