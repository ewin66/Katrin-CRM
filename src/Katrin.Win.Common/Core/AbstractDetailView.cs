using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Katrin.Win.Common.Constants;
using Katrin.Win.Infrastructure.Services;
using DevExpress.Utils.Serializing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Properties;
using System.Text;
using DevExpress.XtraLayout;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Reflection;
using Katrin.Win.Infrastructure;
using DevExpress.XtraRichEdit;

namespace Katrin.Win.Common.Core
{
    public partial class AbstractDetailView : View, IUserDataPersister, IEntityDetailView
    {
        [EventPublication(EventTopicNames.ObjectChanged, PublicationScope.WorkItem)]
        public event EventHandler ObjectChanged;

        [EventPublication(EventTopicNames.OpenDetail, PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid, Type,String>> OpenDetailById;

        protected void OnObjectChanged(EventArgs e)
        {
            EventHandler handler = ObjectChanged;
            if (handler != null) handler(this, e);
        }

        public bool OpenDetail(Guid id, Type detailViewType,string entityName)
        {
            EventHandler<EventArgs<Guid, Type,String>> handler = OpenDetailById;
            if (handler != null) handler(this, new EventArgs<Guid, Type, String>(id, detailViewType, entityName));
            return true;
        }

        public AbstractDetailView()
        {
            InitializeComponent();
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

        public UserDataPersistenceService UserDataPersistenceService { get; set; }
        public string EntityName { get; set; }
        protected void SetValidationRule(Control control, ValidationRuleBase rule)
        {
            SetValidationRuleAligRight(ValidationProvider, control, rule);
        }

        protected static void SetValidationRuleAligRight(DXValidationProvider provider, Control control, ValidationRuleBase rule)
        {
            provider.SetValidationRule(control, rule);
            provider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        }

        public virtual void InitEditors(Entity entity)
        {
            Stream tream = GetDefaultLayoutStream(EntityName);
            if (tream != null)
                EntityDataLayoutControl.RestoreLayoutFromStream(tream);
            EntityDataLayoutControl.Controls.OfType<BaseEdit>().ToList().ForEach(editor => LocalizeProperty(editor, entity));
            EntityDataLayoutControl.Controls.OfType<RichEditControl>().ToList().ForEach(editor => LocalizeProperty(editor, entity));
            InitValidation();
        }

        public void TurnOnChangeTracker()
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
                                 edit.Properties.BeginInit();
                                 edit.Properties.ReadOnly = isReadOnly;
                                 edit.Properties.EndInit();
                             });
            EntityDataLayoutControl.Controls.OfType<RichEditControl>().ToList()
               .ForEach(edit => edit.ReadOnly = isReadOnly);
        }

        public virtual void Bind(object entity)
        {
            EntityBindingSource.DataSource = entity;
            UserDataPersistenceService.LoadUserData(this);
        }

        public virtual void InitValidation()
        {
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
                ForeceTabGroupInitialize();
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

            foreach (var invalidControl in invalidControls)
            {
                var message = ValidationProvider.GetValidationRule(invalidControl).ErrorText;
                invalidMessage.AppendLine(message);
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
            var labels = MetadataProvider.Instance.LocalizedLabels;
            var binding = editor.DataBindings[0];
            string bindingMember = binding.BindingMemberInfo.BindingMember;
            var bindingSource = binding.DataSource as BindingSource;
            string dataMember = bindingSource != null?bindingSource.DataMember:string.Empty;
            var attribute = GetEntityAttribute(entity, bindingMember);
            if (!string.IsNullOrEmpty(dataMember))
            {
                attribute = entity.Attributes
                        .FirstOrDefault(a => a.PhysicalName.Contains(dataMember));
                var relationRoles = MetadataProvider.Instance.EntityRelationshipRoles
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
                    entity = MetadataProvider.Instance.EntiyMetadata.First(c => c.EntityId == entityId);
                    attribute = entity.Attributes
                        .FirstOrDefault(a => a.PhysicalName.Equals(bindingMember, StringComparison.InvariantCultureIgnoreCase));
                }
            }
            if (attribute != null)
            {
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

        private void SaveLayout(State state, string name, ISupportXtraSerializer serializer)
        {
            using (var stream = new MemoryStream())
            {
                serializer.SaveLayoutToStream(stream);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    state[name] = reader.ReadToEnd();
                }
            }
        }

        private void RestoreLayout(State state, string name, ISupportXtraSerializer serializer)
        {
            using (var stream = new MemoryStream())
            {
                var layout = (string) state[name];
                if (string.IsNullOrEmpty(layout)) return;
                var writter = new StreamWriter(stream);
                writter.AutoFlush = true;
                writter.Write(layout);
                stream.Position = 0;
                serializer.RestoreLayoutFromStream(stream);
            }
        }

        private Stream GetDefaultLayoutStream(string entityName)
        {
            Assembly asm = this.GetType().Assembly;
            string localName = System.Globalization.CultureInfo.CurrentCulture.Name.Replace("-","");
            Stream stream = asm.GetManifestResourceStream("Katrin.Win.MainModule.DefaultLayout." + entityName + ".Detail" + localName + ".xml");
            return stream;
        }

        public void SaveUserData(State state)
        {
            SaveLayout(state,"DetailLayout",EntityDataLayoutControl);
        }

        public void LoadUserData(State state)
        {
            RestoreLayout(state, "DetailLayout", EntityDataLayoutControl);
        }
    }

    public class ValidationRules
    {
        static ConditionValidationRule _isNotBlankRule;
        static ConditionValidationRule _isValidationDateRule;
        static ConditionValidationRule _isNotSelectRule;

        public static ConditionValidationRule IsGuidNotBlankRule(string fieldText)
        {
            var rule = new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.NotAnyOf,
                ErrorText = string.Format(Resources.ValidateNotBlankMessage, fieldText),
                ErrorType = ErrorType.Critical
            };
            rule.Values.Add(null);
            rule.Values.Add(Guid.Empty);
            rule.Values.Add(DBNull.Value);
            return rule;
        }

        public static ConditionValidationRule IsNotZeroRule(string fieldText)
        {
            var rule = new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.NotAnyOf,
                ErrorText = string.Format(Resources.ValidateNotBlankMessage, fieldText),
                ErrorType = ErrorType.Critical
            };
            rule.Values.Add(null);
            rule.Values.Add(0);
            rule.Values.Add(DBNull.Value);
            return rule;
        }

        public static ConditionValidationRule IsNotBlankRule(string fieldText)
        {
            return new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.IsNotBlank,
                ErrorText = string.Format(Resources.ValidateNotBlankMessage, fieldText),
                ErrorType = ErrorType.Critical
            };
        }

        public static ConditionValidationRule IsBlankWarningRule(string fieldText)
        {
            return new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.IsNotBlank,
                ErrorText = string.Format(Resources.ValidateNotBlankMessage, fieldText),
                ErrorType = ErrorType.Warning
            };
        }

        public static ConditionValidationRule IsValidationDateRule
        {
            get
            {
                return _isValidationDateRule ??
                       (_isValidationDateRule = new ConditionValidationRule
                       {
                           ConditionOperator = ConditionOperator.NotEquals,
                           ErrorText = Resources.ValidateDate,
                           ErrorType = ErrorType.Critical,
                           Value1 = DateTime.MinValue
                       });
            }
        }

        public static ConditionValidationRule IsNotSelectRule
        {
            get
            {
                return _isNotSelectRule ??
                       (_isNotSelectRule = new ConditionValidationRule
                       {
                           ConditionOperator = ConditionOperator.NotEquals,
                           ErrorText = Resources.ValidateNotBlankMessage,
                           ErrorType = ErrorType.Critical,
                           Value1 = new Guid(),
                           Value2 = Guid.Empty
                       });
            }
        }
    }
}
