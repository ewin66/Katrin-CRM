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

namespace Katrin.Win.ProjectIterationModule.Version
{
    
    public partial class ProjectVersionDetailView : DetailView, IProjectVersionDetailView
    {
        public event EventHandler<EventArgs<Guid>> OnProjectChange;


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
