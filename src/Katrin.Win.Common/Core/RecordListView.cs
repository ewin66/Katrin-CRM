using System;
using System.Windows.Forms;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Controls;
using Katrin.Win.Infrastructure;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using Microsoft.Practices.CompositeUI;
using DevExpress.XtraGrid.Views.Base;
using Katrin.Win.Infrastructure.Services;
using DevExpress.XtraBars.Docking;
using System.IO;
using DevExpress.Utils.Serializing;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Xml.Serialization;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using Katrin.Win.WcfServerMode;
using System.Collections;

namespace Katrin.Win.Common.Core
{
    public partial class RecordListView : View, IUserDataPersister
    {
        [EventPublication(EventTopicNames.FocusedRowChanged, PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<object>> FocusedRowChanged;

        public RecordListView()
        {
            InitializeComponent();
            entityGridControl.MouseUp += entityGridControl_MouseUp;
            Context.BindingSource.PositionChanged += OnFocusedRowChanged;
        }

        protected override void OnContextChanging(ContextChangingEventArgs e)
        {
            base.OnContextChanging(e);
            if (e.Original != null) e.Original.BindingSource.PositionChanged -= OnFocusedRowChanged;
            if (e.New != null) e.New.BindingSource.PositionChanged += OnFocusedRowChanged;
        }

        protected override void OnContextChanged(EventArgs e)
        {
            base.OnContextChanged(e);
            entityGridControl.DataSource = Context.BindingSource;
        }


        protected virtual Dictionary<string, string> IncludingPath
        {
            get { return null; }
        }

        /// <summary>
        /// Fixed predicate of the list data
        /// </summary>
        public CriteriaOperator FixedPredicate { get; set; }

        private ColumnView _entityGridView;
        public virtual ColumnView EntityGridView
        {
            get
            {
                if (_entityGridView == null)
                {
                    _entityGridView = CreateDataView();
                    _entityGridView.ColumnFilterChanged += OnFocusedRowChanged;
                    _entityGridView.RowCountChanged += OnFocusedRowChanged;
                    _entityGridView.DoubleClick += EntityGridViewDoubleClick;
                    entityGridControl.HandleDestroyed += entityGridControl_HandleDestroyed;
                    if (_entityGridView.GridControl == null)
                    {
                        entityGridControl.MainView = _entityGridView;
                        entityGridControl.ViewCollection.Add(_entityGridView);
                        _entityGridView.GridControl = entityGridControl;
                    }
                }
                return _entityGridView;
            }
        }

        void entityGridControl_HandleDestroyed(object sender, EventArgs e)
        {
            if (_persistenceService != null)
                _persistenceService.SaveUserData(this);
        }

        void OnFocusedRowChanged(object sender, EventArgs e)
        {
            var handler = FocusedRowChanged;
            if (handler != null) handler(this, new EventArgs<object>(SelectedEntity));
        }

        public string EntityName
        {
            get;
            protected set;
        }

        protected virtual void EntityGridViewDoubleClick(object sender, EventArgs e)
        {

        }

        protected virtual void InitConvert()
        {

        }

        public object SelectedEntity
        {
            get 
            {
                return Context.BindingSource.Current; 
            }
        }

        protected virtual ColumnView CreateDataView()
        {
            var entityGridView = new GridView();
            return entityGridView;
        }

        public DockManager DockManager
        {
            get { return dockManager1; }
        }

        /// <summary>
        /// Bind the list
        /// </summary>
        /// <param name="entityName">the entity name</param>
        public virtual void Bind(string entityName)
        {
            BindData();
        }

        protected override void BindData()
        {
            var filterCriteria = Context.GetFilters();
            filterCriteria &= FixedPredicate;
            UnsubscribleEvents();
            Action onCompleted = () => {
                UnsubscribleEvents();
                SubscribleEvents();
                OnFocusedRowChanged(this, new EventArgs());
            };
            EntityGridView.BindDataAsync(Context, EntityName, onCompleted, filterCriteria, IncludingPath);
        }

        private void SubscribleEvents()
        {
            Context.BindingSource.PositionChanged += OnFocusedRowChanged;
            EntityGridView.ColumnFilterChanged += OnFocusedRowChanged;
            EntityGridView.RowCountChanged += OnFocusedRowChanged;
        }

        private void UnsubscribleEvents()
        {
            Context.BindingSource.PositionChanged -= OnFocusedRowChanged;
            EntityGridView.ColumnFilterChanged -= OnFocusedRowChanged;
            EntityGridView.RowCountChanged -= OnFocusedRowChanged;
        }

        private UserDataPersistenceService _persistenceService;
        public void InitEntityView(string entityName)
        {
            EntityName = entityName;
            EntityGridView.BeginUpdate();
            EntityGridView.LoadDefaultLayout(entityName);
            EntityGridView.InitColumns(entityName);
            _persistenceService = new UserDataPersistenceService(entityName + "List");
            object savedLayout = _persistenceService["GridLayout"];
            if (savedLayout != null)
            {
                string layoutXml = savedLayout.ToString();
                EntityGridView.RestoreLayoutFromString(layoutXml);
            }

            if (_persistenceService["Fileter"] != null)
            {
                string filter = _persistenceService["Fileter"].ToString();
                CriteriaOperator criteria = CriteriaOperator.TryParse(filter);
                Context.SetFilter("GridFilter", criteria);
            }
            LoadUserFormatCondition();
            EntityGridView.EndUpdate();
            InitConvert();
        }

        public virtual void SaveUserData(State state)
        {
            SaveLayout(state, "GridLayout", EntityGridView);
            CriteriaOperator criteria = Context.GetFilter("GridFilter");
            state["Fileter"] = null;
            if ((object)criteria != null)
            {
                state["Fileter"] = criteria.ToString();
            }
            //SaveLayout(state, "DockManager", dockManager1);
        }

        private void SaveLayout(State state, string name, ColumnView serializer)
        {
            using (var stream = new MemoryStream())
            {
                serializer.SaveLayoutToStream(stream,DevExpress.Utils.OptionsLayoutBase.FullLayout);
                stream.Position = 0;
                var reader = new StreamReader(stream);
                state[name] = reader.ReadToEnd();
            }
        }

        public virtual void LoadUserData(State state)
        {
            RestoreLayout(state, "GridLayout", EntityGridView);
            //RestoreLayout(state, "DockManager", dockManager1);
        }

        private void LoadUserFormatCondition()
        {
            string formatsDirectory = Path.Combine(Application.StartupPath, "Formats");
            string viewFormatDirectory = Path.Combine(formatsDirectory, EntityName);
            if (!Directory.Exists(viewFormatDirectory)) return;
            var formatFiles = Directory.GetFiles(viewFormatDirectory);
            foreach (var file in formatFiles)
            {
                Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                if (stream.Length <= 0) { stream.Close();continue; }
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<FormatCondition.FormatCondition>));
                var list = (List<FormatCondition.FormatCondition>)xmlFormatter.Deserialize(stream);
                foreach (var conditionItem in list)
                {
                    EntityGridView.FormatConditions.Add(FormatCondition.FormatConditionListPresenter.CreateStyleFormatCondition(conditionItem));
                }
                stream.Close();
            }
        }

        private void RestoreLayout(State state, string name, ISupportXtraSerializer serializer)
        {
           
            using (var stream = new MemoryStream())
            {
                var layout = (string)state[name];
                if (string.IsNullOrEmpty(layout)) return;
                var writter = new StreamWriter(stream);
                writter.AutoFlush = true;
                writter.Write(layout);

                stream.Position = 0;
                serializer.RestoreLayoutFromStream(stream);
            }
        }

        public void DeleteFocusedRow()
        {
            EntityGridView.DeleteRow(EntityGridView.FocusedRowHandle);
        }

        private void entityGridControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var gridView = EntityGridView as GridView;
            if (gridView != null && !gridView.CalcHitInfo(e.Location).InRow)
                return;
            var layoutView = EntityGridView as LayoutView;
            if (layoutView != null && !layoutView.CalcHitInfo(e.Location).InField)
                return;

            popupMenu.ShowPopup(entityGridControl.PointToScreen(e.Location));
        }

        protected void RegisterPoupMenuItem(string commandName, string imageName, Action<object> action)
        {
            RegisterPoupMenuItem(commandName, "", imageName, action);
        }

        protected void RegisterPoupMenuItem(string commandName, string formatName, string imageName, Action<object> action)
        {
            var localizedCaption = GetLocalizedCaption(commandName);
            if (formatName != "")
            {
                localizedCaption = string.Format(GetLocalizedCaption(formatName), localizedCaption);
            }
            var buttonItem = new BarButtonItemEx(imageName, null) { Caption = localizedCaption };
            buttonItem.ItemClick += (s, e) =>
            {
                var focusedObject = EntityGridView.GetRow(EntityGridView.FocusedRowHandle);
                if (formatName != "")
                    action(commandName);
                else
                    action(focusedObject);
            };
            popupMenu.AddItem(buttonItem);
        }


        protected string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }

        class EntityListAsychronizeResult
        {
            public object List { get; set; }
            public string EntityName { get; set; }
        }
    }
}
