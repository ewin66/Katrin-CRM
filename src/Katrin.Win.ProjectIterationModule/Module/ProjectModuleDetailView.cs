using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Utils;


namespace Katrin.Win.ProjectIterationModule.Module
{
    
    public partial class ProjectModuleDetailView : DetailView, IProjectModuleDetailView
    {
        public event EventHandler<EventArgs<Guid>> OnProjectChange;


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
