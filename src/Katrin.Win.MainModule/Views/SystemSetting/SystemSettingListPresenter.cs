using System;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI;
using System.Collections.Generic;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;

namespace Katrin.Win.MainModule.Views.SystemSetting
{
    public class SystemSettingListPresenter : Presenter<ISystemSettingListView>
    {
        private  List<object> _entityList;

        #region Save And SaveAndClose Mothod

        [State("WorkingMode")]
        public EntityDetailWorkingMode WorkingMode
        {
            get;
            set;
        }

        [CommandHandler("Save")]
        public void OnView(object sender, EventArgs e)
        {
            SaveEntity();
        }

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        [CommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (SaveEntity())
                WorkItem.Commands["Exit"].Execute();
        }

        private bool SaveEntity()
        {
            foreach (object _entity in _entityList)
            {
                DynamicDataServiceContext.UpdateObject(_entity);
                DynamicDataServiceContext.SaveChanges();
            }
            WorkItem.Commands["Refresh"].Execute();
            return true;
        }
        #endregion

        protected override void OnViewSet()
        {
            base.OnViewSet();
            string entityName = "SystemSetting";
            _entityList = new List<object>{DynamicDataServiceContext.GetObjects(entityName)};
            View.Bind(_entityList);
            
        }

        //private IEntityService _entityService;

        //public SystemSettingListPresenter(IEntityService entityService, ISystemSettingListView view)
        //{
        //    View = view;
        //    _entityService = entityService;
        //    View.OK += ViewOK;
        //}

        //public override void Start()
        //{
        //   var list = _entityService.GetSystemSettings();
        //   View.BindConfiguration(list);
        //   View.ShowDialog();
        //}

        //public void Close()
        //{
        //    View.Close();
        //}
        //void ViewOK(object sender, EventArgs e)
        //{
        //    foreach (var configuration in View.Configurations)
        //    {
        //        _entityService.SaveSystemSetting(configuration);
        //    }
        //}
    }
}
