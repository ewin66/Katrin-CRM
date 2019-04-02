using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Controls;
using DevExpress.Data;
using DevExpress.Data.WcfLinq;
using DevExpress.XtraEditors;
using Katrin.Win.Common.MetadataServiceReference;
using System.Reflection;
using System.IO;
using DevExpress.Utils;
using System.Collections;
using Katrin.Win.Common;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Katrin.Win.Common.Core;
using System.Data.Services.Client;
using System.Linq.Expressions;
using DevExpress.Data.Filtering;

namespace Katrin.Win
{
    public static class SearchLookUpEditExtension
    {
        class SearchLookUpEditLoadDataContext
        {
            public WcfRepositoryItemSearchLookUpEdit RepositoryItem { get; set; }
            public object Result { get; set; }
            public Action CompletedAction { get; set; }
        }

        public static void BindDataAsync(this WcfRepositoryItemSearchLookUpEdit repositoryItem, string entityName, Action completedAction, CriteriaOperator commonFilter)
        {
            var worker = new BackgroundWorker();
            var context = new SearchLookUpEditLoadDataContext();
            context.RepositoryItem = repositoryItem;
            context.CompletedAction = completedAction;
            repositoryItem.View.LoadDefaultLayout(repositoryItem.EntityName);
            repositoryItem.View.InitColumns(repositoryItem.EntityName);
            worker.DoWork += (s, e) =>
                                 {
                                     var query = repositoryItem.View.CreateQuery(entityName, commonFilter, null);
                                     context.Result = query.ToArrayList();
                                     e.Result = context;
                                 };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync(repositoryItem);
        }

        public static void BindSeverMode(this SearchLookUpEdit searchLookUpEdit, Entity entity)
        {
            if (entity == null) return;
            if (searchLookUpEdit.DataBindings.Count == 0) return;

            var binding = searchLookUpEdit.DataBindings[0];

            string attributeName = binding.BindingMemberInfo.BindingMember;

            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName.Equals(attributeName));
            var lookupValue = attribute.AttributeLookupValues.First();
            var lookupValueEntity = lookupValue.Entity;

            searchLookUpEdit.Properties.BeginInit();

            var entityName = lookupValueEntity.PhysicalName;
            var displayAttribute =
                lookupValueEntity.Attributes.First(a => a.AttributeId == lookupValue.DisplayEntityAttributeId);
            searchLookUpEdit.Properties.DisplayMember = displayAttribute.PhysicalName;

            var primaryKeyAttribute =
                lookupValueEntity.Attributes.Single(a => a.IsPKAttribute.HasValue && a.IsPKAttribute.Value);
            searchLookUpEdit.Properties.ValueMember = primaryKeyAttribute.PhysicalName;
            searchLookUpEdit.Properties.NullText = string.Empty;
            searchLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
            searchLookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            searchLookUpEdit.Properties.ShowFooter = false;
            searchLookUpEdit.Properties.View.LoadDefaultLayout(entityName);
            searchLookUpEdit.Properties.View.InitColumns(entityName);
            var query = searchLookUpEdit.Properties.View.CreateQuery(entityName, null, null);
            var source = new WcfInstantFeedbackSource();
            source.GetSource += (s, e) =>
            {
                e.Query = query;
                e.KeyExpression = primaryKeyAttribute.PhysicalName;
            };
            searchLookUpEdit.Properties.DataSource = source;
            searchLookUpEdit.Properties.EndInit();
        }

        static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var context = (SearchLookUpEditLoadDataContext)e.Result;
            context.RepositoryItem.BeginInit();
            context.RepositoryItem.DataSource = context.Result;
            context.RepositoryItem.EndInit();
            if (context.CompletedAction != null) context.CompletedAction();
            //context.RepositoryItem.ForeceActiveGridDataSource();
        }

        public static Type GetElementType(this IEnumerable source)
        {
            var genericEnumerable =
                source.GetType().GetInterfaces().FirstOrDefault(
                    x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (genericEnumerable != null)
            {
                var type = genericEnumerable.GetGenericArguments().First();
                return type;
            }
            return null;
        }

        public static IList ToList(this DataServiceQuery source)
        {
            Expression thisExpression = Expression.Constant(source);
            MethodCallExpression methodCallExpression =
                Expression.Call(typeof(Enumerable), "ToList",
                                new Type[1] { source.ElementType }, thisExpression);

            var result = Expression.Lambda(methodCallExpression).Compile().DynamicInvoke();
            return (IList)result;
        }

        public static IList ToArrayList(this IEnumerable source)
        {
            var type = source.GetElementType();
            if (type != null)
            {
                var listType = typeof(List<>).MakeGenericType(type);
                var list = (IList)Activator.CreateInstance(listType, source);
                return list;
            }
            else
            {
                var enumerator = source.GetEnumerator();
                var list = new ArrayList();
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
                return list;
            }

        }

        public static void AddDetailButton<TDetailView>(this SearchLookUpEdit searchLookUpEdit, Func<Guid, Type, String, bool> fuc, string entityName) where TDetailView : AbstractDetailView
        {
            searchLookUpEdit.Properties.Buttons.Add(new EditorButton());
            searchLookUpEdit.ButtonClick += (sender, e) =>
            {
                if (searchLookUpEdit.EditValue == null
                    || e.Button.Kind != ButtonPredefines.Ellipsis
                    || searchLookUpEdit.EditValue == DBNull.Value)
                    return;
                var entityId = (Guid)searchLookUpEdit.EditValue;
                fuc(entityId, typeof(TDetailView), entityName);
                //string key = entityId + ":DetailWorkItem";

                //var detailWorkItem = Items.Get<EnityDetailController<TDetailView>>(key);

                //if (detailWorkItem == null)
                //{
                //    detailWorkItem = Items.AddNew<EnityDetailController<TDetailView>>(key);
                //    detailWorkItem.EntityName = entityName;
                //    detailWorkItem.Initialize();
                //}

                //detailWorkItem.State["EntityId"] = id;
                //detailWorkItem.State["WorkingMode"] = workingMode;
                //detailWorkItem.Run();



                //var eventAggregator =
                //    ServiceLocator.Current.GetInstance<IEventAggregator>();
                //var viewEvent = eventAggregator.GetEvent<DisplayFormViewEvent>();
                //viewEvent.Publish(new DisplayFormViewEvent(typeof(TDetailPresenter))
                //{
                //    EntityId = entityId,
                //    Mode = ViewDetailMode.View
                //});
            };
        }
    }
}
