using Katrin.AppFramework;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using DevExpress.XtraGrid.Views.Base;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Context;
using System.IO;
using System.Reflection;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.Metadata;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using Katrin.AppFramework.ConfigService;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.DetailViewModule
{
   
    public partial class DetailView : Katrin.AppFramework.WinForms.Views.BaseView, IObjectDetailView,ILayoutRemember
    {
        private IConfigService _Config = new ConfigService();
        protected Dictionary<string,string> _validationSort = new Dictionary<string,string>();
        public DetailView()
        {
            InitializeComponent();
        }

        public event EventHandler ObjectChanged;

        protected void OnObjectChanged(EventArgs e)
        {
            EventHandler handler = ObjectChanged;
            if (handler != null) handler(this, e);
        }

        public virtual void BeginInit()
        {
            EntityDataLayoutControl.BeginInit();
            SuspendLayout();
        }

        public virtual void EndInit()
        {
            EntityDataLayoutControl.EndInit();
            ResumeLayout(false);
        }

        protected void SetValidationRule(Control control, ValidationRuleBase rule)
        {
            SetValidationRuleAligRight(ValidationProvider, control, rule);
        }

        protected void SetValidationRuleAligRight(DXValidationProvider provider, Control control, ValidationRuleBase rule)
        {
            if (!_validationSort.Keys.Contains(control.Name)) _validationSort.Add(control.Name,string.Empty);
            provider.SetValidationRule(control, rule);
            provider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        }

        public virtual void InitEditors(Entity entity)
        {
            EntityDataLayoutControl.Controls.OfType<BaseEdit>().ToList().ForEach(editor => LocalizeProperty(editor, entity));
            EntityDataLayoutControl.Controls.OfType<RichEditControl>().ToList().ForEach(editor => LocalizeProperty(editor, entity));
            InitValidation();
        }

        private void TurnOnChangeTracker()
        {
            EntityDataLayoutControl.Controls.OfType<BaseEdit>().ToList()
                .ForEach(edit => edit.EditValueChanged += (o, args) => OnObjectChanged(args));
            EntityDataLayoutControl.Controls.OfType<RichEditControl>().ToList()
                .ForEach(edit => edit.ContentChanged += (o, args) => OnObjectChanged(args));
        }

        public virtual void SetEditorStatus(bool isReadOnly)
        {
            EntityDataLayoutControl.Controls.OfType<BaseEdit>().ToList()
                .ForEach(edit =>
                             {
                                 //edit.Properties.BeginInit();
                                 edit.Properties.ReadOnly = isReadOnly;
                                 //edit.Properties.EndInit();
                             });
            EntityDataLayoutControl.Controls.OfType<RichEditControl>().ToList()
               .ForEach(edit => edit.ReadOnly = isReadOnly);
        }

        public virtual void Bind(object entity)
        {
            EntityBindingSource.DataSource = entity;
        }

        public virtual void InitValidation()
        {
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
            RibbonFormWorkspace frm = this.Parent as RibbonFormWorkspace;
       
            if (!DesignMode)
                ForeceTabGroupInitialize();
            TurnOnChangeTracker();
        }

    

        public virtual void PostEditors()
        {
            EntityDataLayoutControl.Controls.OfType<BaseEdit>().ToList().ForEach(edit => edit.DoValidate(PopupCloseMode.Normal));
        }

        protected void ForeceTabGroupInitialize()
        {
            foreach (BaseLayoutItem item in EntityDataLayoutControl.Root.Items)
            {
                var tabItem = item as TabbedControlGroup;
                if (tabItem != null)
                {
                    for (int index = 0; index < tabItem.TabPages.Count; index++)
                    {
                        tabItem.SelectedTabPageIndex = index;
                    }
                    tabItem.SelectedTabPageIndex = 0;
                }
            }
        }

        public virtual bool ValidateData()
        {
            messagePanel.ResetText();
            messagePanel.Visible = false;
            var result = ValidationProvider.Validate();
            var invalidControls = ValidationProvider.GetInvalidControls();
            var invalidMessage = new StringBuilder();
            _validationSort.ToList().ForEach(c => _validationSort[c.Key] = string.Empty);
            foreach (var invalidControl in invalidControls)
            {
                var message = ValidationProvider.GetValidationRule(invalidControl).ErrorText;
                if (_validationSort.Keys.Contains(invalidControl.Name))
                    _validationSort[invalidControl.Name] = message;
                else
                    invalidMessage.AppendLine(message);
            }
            foreach (var validationItem in _validationSort)
            {
                if (string.IsNullOrEmpty(validationItem.Value)) continue;
                invalidMessage.AppendLine(validationItem.Value);
            }
            if (invalidMessage.Length > 0)
            {
                messagePanel.Visible = true;
                messagePanel.Text = invalidMessage.ToString();
            }

            var firstInvalideControl = invalidControls.FirstOrDefault();

            if (firstInvalideControl != null)
            {
                var layoutItem = EntityDataLayoutControl.GetItemByControl(firstInvalideControl);
                if (layoutItem != null && layoutItem.Parent.ParentTabbedGroup != null)
                {
                    layoutItem.Parent.ParentTabbedGroup.SelectedTabPage = layoutItem.Parent;
                }
            }
            return result;
        }


        private void LocalizeProperty(Control editor, Entity entity)
        {
            if (editor.DataBindings.Count == 0)
                return;
            var labels = MetadataRepository.LocalizedLabels;
            var binding = editor.DataBindings[0];
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            string bindingMember = binding.BindingMemberInfo.BindingMember;
            var bindingSource = binding.DataSource as BindingSource;
            string dataMember = bindingSource != null?bindingSource.DataMember:string.Empty;
            var attribute = GetEntityAttribute(entity, bindingMember);
            
      

            if (!string.IsNullOrEmpty(dataMember))
            {
                attribute = entity.Attributes
                        .FirstOrDefault(a => a.PhysicalName.Contains(dataMember));
                var relationRoles = MetadataRepository.EntityRelationshipRoles
                    .Where(c => c.EntityId == entity.EntityId && c.RelationshipRoleType == 1 
                        && c.EntityRelationship.EntityRelationshipRelationships
                        .FirstOrDefault() == null ? false : 
                        c.EntityRelationship.EntityRelationshipRelationships
                        .First().Relationship.ReferencingAttributeId == attribute.AttributeId);
                if (relationRoles != null)
                {
                    var entityId = relationRoles.First().EntityRelationship
                        .EntityRelationshipRelationships.First()
                        .Relationship.ReferencedEntityId;
                    entity = MetadataRepository.Entities.First(c => c.EntityId == entityId);
                    attribute = entity.Attributes
                        .FirstOrDefault(a => a.PhysicalName.Equals(bindingMember, StringComparison.InvariantCultureIgnoreCase));
                }
            }
            if (attribute != null)
            {
                //textbox maxlength setting
                if (editor is DevExpress.XtraEditors.TextEdit)
                {
                    TextEdit txtControl = editor as TextEdit;
                    if (attribute.MaxLength != null)
                    {
                        txtControl.Properties.MaxLength = (int)attribute.MaxLength;
                    }
                }
                //setting local language.
                int languageId = System.Threading.Thread.CurrentThread.CurrentUICulture.LCID;
                var label = labels.FirstOrDefault(l => l.ObjectId == attribute.AttributeId && l.LanguageId == languageId);
                if (label != null)
                {
                    var layoutItem = EntityDataLayoutControl.GetItemByControl(editor);
                    layoutItem.Text = label.Label;
                }
            }
        }

        private static EntityAttribute GetEntityAttribute(Entity entity, string bindingMember)
        {
            var attributeName = bindingMember;
            var segments = bindingMember.Split('.');
            if (segments.Length == 2) attributeName = segments[0] + "Id";
            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName == attributeName);
            return attribute;
        }
        private Stream GetDefaultLayoutStream(string entityName)
        {
            Assembly asm = this.GetType().Assembly;
            string localName = System.Globalization.CultureInfo.CurrentCulture.Name.Replace("-","");
            Stream stream = asm.GetManifestResourceStream("Katrin.Win.MainModule.DefaultLayout." + entityName + ".Detail" + localName + ".xml");
            return stream;
        }
        public void Close()
        {
            if (ParentForm != null) ParentForm.Close();
        }

        #region ILayoutRemember
        public void SaveLayout()
        {
            RibbonFormWorkspace frm = this.Parent as RibbonFormWorkspace;
            if(frm != null)
            {              
                this._Config.SaveDataLayoutControl(this.EntityDataLayoutControl, frm.ObjectName);
            }
        }

        public void RestoreLayout()
        {
            this.EntityDataLayoutControl.SetDefaultLayout();
            RibbonFormWorkspace frm = this.Parent as RibbonFormWorkspace;
            if (frm != null)
            {              
                this._Config.RestoreDataLayoutControl(this.EntityDataLayoutControl, frm.ObjectName);
                
            }
        }

        public void RestoreDefaultLayout()
        {
            this.EntityDataLayoutControl.RestoreDefaultLayout();
        }

        public void SaveDefaultLayout()
        {
            this.EntityDataLayoutControl.SetDefaultLayout();
        }
        #endregion





        
    }
}
