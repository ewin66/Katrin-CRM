using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Infrastructure;
using Katrin.Win.MainModule.Views.ProjectVersion;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;

namespace Katrin.Win.MainModule.Views.ProjectVersion
{
    
    [SmartPart]
    public partial class ProjectVersionDetailView : AbstractDetailView, IProjectVersionDetailView
    {
        public event EventHandler<EventArgs<Guid>> OnProjectChange;
        private ProjectVersionDetailPresenter _presenter;

        [CreateNew]
        public ProjectVersionDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public ProjectVersionDetailView()
        {
            InitializeComponent();
        }

        public void SetProjectEable(bool enable)
        {
        }

        public override void InitValidation()
        {
            SetValidationRule(VersionNumberTextEdit, ValidationRules.IsNotBlankRule(ItemForVersionNumber.Text));
        }

        public bool ValidateResult { get; set; }
    }
}
