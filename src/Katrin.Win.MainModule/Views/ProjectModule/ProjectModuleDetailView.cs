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
using Katrin.Win.MainModule.Views.ProjectModule;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;

namespace Katrin.Win.MainModule.Views.ProjectModule
{
    
    [SmartPart]
    public partial class ProjectModuleDetailView : AbstractDetailView, IProjectModuleDetailView
    {
        public event EventHandler<EventArgs<Guid>> OnProjectChange;
        private ProjectModuleDetailPresenter _presenter;

        [CreateNew]
        public ProjectModuleDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public ProjectModuleDetailView()
        {
            InitializeComponent();
        }

        public void SetProjectEable(bool enable)
        {
        }

        public override void InitValidation()
        {
            SetValidationRule(ModuleNameTextEdit, ValidationRules.IsNotBlankRule(ItemForModuleName.Text));
        }

        public bool ValidateResult { get; set; }
    }
}
