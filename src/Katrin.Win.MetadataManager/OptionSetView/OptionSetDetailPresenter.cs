using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using System.ComponentModel;
using Katrin.Win.Common;

namespace Katrin.Win.MetadataManager.OptionSetView
{
    public class OptionSetDetailPresenter : Presenter<IOptionSetDetailView>
    {
        public Guid optionSetId { get; set; }
        public  EntityDetailWorkingMode WorkingMode { get; set; }
        private OptionSetDTO entity;
        private MetadataServiceClient metadataService = new MetadataServiceClient();

        

        protected override void OnViewSet()
        {
            base.OnViewSet();
            var metadataService = MetadataProvider.CreateServiceClient();
            View.SaveOptionSet += SaveOptionSet;
            int langId = System.Globalization.CultureInfo.CurrentCulture.LCID;
            entity = WorkingMode== EntityDetailWorkingMode.Add?
                new OptionSetDTO() : metadataService.GetOptionSetById(optionSetId, langId).First();
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                entity.OptionSetId = optionSetId;
                entity.OptionList = new List<OptionDTO>();
            }
            List<OptionSetDTO> list = new List<OptionSetDTO>();
            list.Add(entity);
            View.Bind(list);
        }

        private void SaveOptionSet(object sender, EventArgs e)
        {
            int langId = System.Globalization.CultureInfo.CurrentCulture.LCID;
            bool isAdd = WorkingMode == EntityDetailWorkingMode.Add ? true : false;
            var metadataService = MetadataProvider.CreateServiceClient();
            metadataService.SaveOptionSet(entity, langId, isAdd);
        }
    }
}
