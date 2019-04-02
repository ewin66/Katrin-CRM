using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common;
using Katrin.Win.Common.Core;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using Katrin.Win.Common.MetadataServiceReference;
using DevExpress.Utils;

namespace Katrin.Win.MetadataManager
{
    public partial class MetadataListView : EntityListView
    {
        public MetadataListView()
        {
            InitializeComponent();
        }

        protected override DevExpress.XtraGrid.Views.Base.ColumnView CreateDataView()
        {
            return this.metadataGridView;
        }

        public override void Bind(string entityName)
        {
            var metadataService = MetadataProvider.CreateServiceClient();
            var metaEntities =  metadataService.GetMetaEntities();

            Context.BindingSource.DataSource = metaEntities;
        }

    }
}
