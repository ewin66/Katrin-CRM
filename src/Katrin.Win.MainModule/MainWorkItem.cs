using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Services;
using Katrin.Win.Common.Constants;
using DevExpress.XtraNavBar;
using Katrin.Win.Common.Core;
using Katrin.Win.MainModule.Properties;
using System.Drawing;
using Katrin.Win.Common.Notification;


namespace Katrin.Win.MainModule
{
    public class MainWorkItem : WorkItem
    {
        //private BarItem queueItem;
        [EventPublication(EventTopicNames.CaptionUpdate, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> CaptionUpdate;

        public void OnCaptionUpdate(EventArgs<string> e)
        {
            EventHandler<EventArgs<string>> handler = CaptionUpdate;
            if (handler != null) handler(this, e);
        }

        // The work item uses the state persistence service that's been registered
        // in the shell initialization
        public IStatePersistenceService PersistenceService
        {
            get { return Services.Get<IStatePersistenceService>(); }
        }

        // Here we populate the work item with some of our views and start showing
        // ourselves. The BankTellerMainView has smart part placeholders named
        // UserInfo and CustomerList; these are filled in at runtime with the
        // smart parts that are registered with those names. We chose to put a
        // UserInfoView in the "UserInfo" placeholder, and a CustomerQueueView
        // in the "CustomerList" placeholder.
        //
        // Note that order is important here. When we create the BankTellerMainView,
        // it is going to assume that the smart parts that it needs already exist
        // in the work item. Therefore, we create the smart parts first, and then
        // create the main view that contains them.
        public void Show(IWorkspace navbarWorkspace, IWorkspace content)
        {
            AddShowNavBarGroups();

            Activate();
        }

        void ShowEntityList(string entityName)
        {
            string captionFormat = GetLocalizedCaption("EntityListCaptionFormat");
            OnCaptionUpdate(new EventArgs<string>(string.Format(captionFormat, GetLocalizedCaption(entityName))));
            string key = entityName + "List";
            var type = FindLoadedType(entityName + "Controller");
            var service = Services.Get<ISingleWorkItemService>();
            var serviceParameter = Expression.Parameter(typeof (ISingleWorkItemService), "service");
            var workItemParameter = Expression.Parameter(typeof (WorkItem), "workItem");
            var keyParameter = Expression.Parameter(typeof (string), "key");
            var typeArguments = new[] {type};
            var call = Expression.Call(serviceParameter, "ShowEntityList",
                                       typeArguments, workItemParameter, keyParameter);
            Expression.Lambda(call, serviceParameter, workItemParameter, keyParameter).Compile()
                .DynamicInvoke(service, this, key);
        }

        public static IQueryable<T> OrderBy<T>(IQueryable<T> source, string sortProperty, ListSortDirection sortOrder)
        {
            var type = typeof(T);
            var property = type.GetProperty(sortProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var typeArguments = new Type[] { type, property.PropertyType };
            var methodName = sortOrder == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
            var resultExp = Expression.Call(typeof(Queryable), methodName, typeArguments, source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<T>(resultExp);
        }

        private static Type FindLoadedType(string typeName)
        {
            return Assembly.GetExecutingAssembly().GetExportedTypes().FirstOrDefault(type => type.Name == typeName);
        }

        private Dictionary<string,List<string>> _moduleGroups= new Dictionary<string, List<string>>();

        private void AddShowNavBarGroups()
        {
            _moduleGroups.Add("Sales", new List<string>(new[]
                                                            {
                                                                "Lead",
                                                                "Opportunity", "Quote",
                                                                "Contract", "Invoice",
                                                                "Account", "Contact"
                                                            }));
            _moduleGroups.Add("ProjectManagement", new List<string>(new[] { "Project", "ProjectTask", "ProjectWeekReport","Attendance" }));
            _moduleGroups.Add("Reports", new List<string>(new[] { "OpportunityReport", "ProjectReport" }));
            _moduleGroups.Add("Services", new List<string>(new[]{"Product","Task"}));
            _moduleGroups.Add("Administration", new List<string>(new[] { "User", "Role" }));
            

            foreach (var moduleGroup in _moduleGroups)
            {
                var group = new NavBarGroup(GetLocalizedCaption(moduleGroup.Key));
                foreach (var module in moduleGroup.Value)
                {
                    if (!AuthorizationManager.CheckAccess(module, "Read")) continue;
                    var localizedCaption = GetLocalizedCaption(module);
                    var item = new NavBarItem(localizedCaption);

                    string moduleName = module;
                    item.LinkClicked += (s, e) => ShowEntityList(moduleName);
                    item.Name = module;
                    item.LargeImage = GetBitmapByName(module, new Size(32, 32));
                    item.SmallImage = GetBitmapByName(module, new Size(32, 32));
                    group.ItemLinks.Add(item);
                }
                if(group.ItemLinks.Count == 0) continue;
                group.LargeImage = GetBitmapByName(moduleGroup.Key, new Size(32, 32));
                group.SmallImage = GetBitmapByName(moduleGroup.Key,new Size(32,32));
                UIExtensionSites[ExtensionSiteNames.ShellNavBar].Add(group);
                UIExtensionSites.RegisterSite(moduleGroup.Key, group);
            }
        }


        private string GetLocalizedCaption(string name)
        {
            return Resources.ResourceManager.GetString(name); 
        }

        private Bitmap GetBitmapByName(string name,Size size)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var rnames = asm.GetManifestResourceNames();
            var tofind = "." + name + ".ico";
            var rname = rnames.Where(c => c.EndsWith(tofind, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (rname != null)
            {
                using (var stream = asm.GetManifestResourceStream(rname))
                {
                    Icon icon = new Icon(stream, size);
                    return icon.ToBitmap();
                }
            }
            return null;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            ShowEntityList("Lead");

            ReceiveNotification.StartReceiveNotification(this);
        }
        
    }
}
