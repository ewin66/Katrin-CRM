using MefContrib.Hosting.Conventions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Katrin.AppFramework
{
    public class ExtensionRegistry : PartRegistry
    {
        public ExtensionRegistry()
        {
            Scan(x =>
            {
                x.Assembly(Assembly.GetExecutingAssembly());
                x.Directory(Environment.CurrentDirectory);
            });

            //// Bootstrapper part is defined in the App.config file

            //Part<ShellPresentationModel>()
            //    .ImportMember(t => t.View)
            //    .MakeShared()
            //    .Export()
            //    .Imports(x =>
            //    {
            //        x.Import<ShellPresentationModel>().Member(m => m.Widgets).ContractType<IWidget>();
            //    });

            //Part<ShellWindow>()
            //    .ExportAs<IShellView>()
            //    .MakeShared();

            //Part()
            //    .ForTypesAssignableFrom<IWidget>()
            //    .ExportAs<IWidget>()
            //    .ImportProperty("PresentationModel");

            //Part()
            //    .ForTypesWhereNamespaceContains("StockTicker")
            //    .Export();
        }
    }
}
