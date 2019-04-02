#region Copyright (c) 2000-2012 Developer Express Inc.
/*
{*******************************************************************}
{                                                                   }
{       Developer Express .NET Component Library                    }
{                                                                   }
{                                                                   }
{       Copyright (c) 2000-2012 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
#endregion Copyright (c) 2000-2012 Developer Express Inc.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using Katrin.Win.WcfServerMode;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Helpers;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.WcfLinq.Helpers;
#if !SL
using System.Windows.Forms;

#else
using DevExpress.Data.Browsing;
using PropertyDescriptor = DevExpress.Data.Browsing.PropertyDescriptor;
#endif
namespace DevExpress.Data.WcfLinq {
	public class WcfServerModeCore : ServerModeCoreExtendable {
		IQueryable source;
		public WcfServerModeCore(IQueryable source, string keyExpression, ServerModeCoreExtender extender)
			: this(source, CriteriaOperator.Parse(keyExpression), extender) {
		}
		public WcfServerModeCore(IQueryable source, CriteriaOperator keyExpression, ServerModeCoreExtender extender)
			: base(new CriteriaOperator[] { keyExpression }, extender) {
			this.source = source;
		}
		static WcfServerModeCore() {
			converter = new CriteriaToExpressionConverter();
		}
		readonly static ICriteriaToExpressionConverter converter;
		public static ICriteriaToExpressionConverter Converter {
			get { return converter; }
		}
		CriteriaOperator SingleKeyCriteria {
			get { return KeysCriteria == null || KeysCriteria.Length == 0 ? null : KeysCriteria[0];  }
		}
		protected override ServerModeKeyedCacheExtendable CreateCacheCoreExtendable() {
			WcfServerModeCache cache = new WcfServerModeCache(source, FilterClause, SingleKeyCriteria, SortInfo, GroupCount, SummaryInfo, TotalSummaryInfo);
			cache.IsFetchRowsGoodIdeaForSureHint_FullestPossibleCriteria = FilterClause;
			return cache;
		}
		protected override object EvaluateOnInstance(object row, CriteriaOperator criteriaOperator) {
			return CriteriaToQueryableExtender.EvaluateOnInstance(WcfServerModeCore.Converter, source.ElementType, row, criteriaOperator);
		}
		protected override bool EvaluateOnInstanceLogical(object startRow, CriteriaOperator filter) {
			object evaluated = CriteriaToQueryableExtender.EvaluateOnInstance(WcfServerModeCore.Converter, source.ElementType, startRow, filter);
			bool rv = ((bool?)evaluated) ?? false;
			return rv;
		}
		protected override object FindFirstKeyByCriteriaOperator(CriteriaOperator filterCriteria, ServerModeOrderDescriptor[] order) {
			try {
				var select = source.Where(filterCriteria)
								   .OrderBy(order)
								   .TakeData(1)
								   .SelectFieldValues(SingleKeyCriteria);
				foreach (object value in select) {
					return value;
				}
			} catch { }
			return null;
		}
		public override IList GetAllFilteredAndSortedRows() {
			IQueryable filteredAndSortedsource = source.Where(FilterClause).OrderBy(SortInfo);
			List<object> result = new List<object>();
			foreach (object row in filteredAndSortedsource) {
				result.Add(row);
			}
			return result;
		}
		protected override object[] GetUniqueValuesInternal(CriteriaOperator expression, int maxCount, CriteriaOperator filter) {
			try {
				var select = source.Where(filter)
								   .GroupBy(expression, false);
				if (maxCount > 0)
					select = select.TakeData(maxCount);
				select = select.SelectFieldValues(new OperandProperty("Key"));
				List<object> rv = new List<object>();
				foreach (object value in select) {
					if (value == null)
						continue;
					rv.Add(value);
				}
				return rv.ToArray();
			} catch {
				return new object[0];
			}
		}
		protected override ServerModeCore DXCloneCreate() {
			return new WcfServerModeCore(source, this.SingleKeyCriteria, Extender);	   
		}
		public static string GuessKeyExpression(Type objectType) {
			try {
				var props = objectType.GetProperties();
				var pk = new List<System.Reflection.PropertyInfo>();
#if !SL //TODO SL
				foreach(var prop in props) {
					foreach(System.Data.Linq.Mapping.ColumnAttribute attr in prop.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), true)) {
						if(attr.IsPrimaryKey) {
							pk.Add(prop);
							break;
						}
					}
				}
#endif
				if(pk.Count == 1) {
					return pk[0].Name;
				} else if (pk.Count > 1) {
					return string.Empty;
				}
				foreach (var prop in props) {
					switch (prop.Name.ToLower()) {
						case "oid":
						case "key":
						case "id":
							return prop.Name;
					}
				}
			} catch { }
			return string.Empty;
		}
	}
}
namespace DevExpress.Data.WcfLinq.Helpers {
	public interface IWcfServerModeFrontEndOwner  {
		Type ElementType { get; }
		DataServiceQuery Query { get; }
		bool IsReadyForTakeOff();
		string KeyExpression { get; }
		string DefaultSorting { get; }
	}
	public class WcfServerModeFrontEnd : IListServer, IListServerHints, IBindingList, ITypedList, IDXCloneable {
		public readonly IWcfServerModeFrontEndOwner Owner;
		readonly ServerModeCoreExtender Extender;
		IListServer _Wrapper;
		Type _Type;
		IQueryable _DataSource;
		bool _IsReadyForTakeOff;
		string _KeyExpression;
		string _DefaultSorting;
		public event EventHandler<ServerModeInconsistencyDetectedEventArgs> InconsistencyDetected;
		public event EventHandler<ServerModeExceptionThrownEventArgs> ExceptionThrown;
		#region reload store
		CriteriaOperator _Successful_FilterCriteria;
		ICollection<ServerModeOrderDescriptor> _Successful_sortInfo;
		int _Successful_groupCount;
		ICollection<ServerModeSummaryDescriptor> _Successful_summaryInfo;
		ICollection<ServerModeSummaryDescriptor> _Successful_totalSummaryInfo;
		#endregion
		#region IDXCloneable Members
		object IDXCloneable.DXClone() {
			return DXClone();
		}
		protected virtual WcfServerModeFrontEnd DXClone() {
			WcfServerModeFrontEnd clone = CreateDXClone();
			clone._Type = this._Type;
			clone._KeyExpression = this._KeyExpression;
			clone._DataSource = this._DataSource;
			clone._IsReadyForTakeOff = this._IsReadyForTakeOff;
			clone._DefaultSorting = this._DefaultSorting;
			clone._Successful_FilterCriteria = this._Successful_FilterCriteria;
			clone._Successful_sortInfo = this._Successful_sortInfo;
			clone._Successful_groupCount = this._Successful_groupCount;
			clone._Successful_summaryInfo = this._Successful_summaryInfo;
			clone._Successful_totalSummaryInfo = this._Successful_totalSummaryInfo;
			return clone;
		}
		protected virtual WcfServerModeFrontEnd CreateDXClone() {
			return new WcfServerModeFrontEnd(this.Owner, Extender);
		}
		#endregion
		protected IListServer Wrapper {
			get {
				if (_Wrapper == null) {
					_Wrapper = CreateWrapper();
					_Wrapper.InconsistencyDetected += new EventHandler<ServerModeInconsistencyDetectedEventArgs>(_Wrapper_InconsistencyDetected);
					_Wrapper.ExceptionThrown += new EventHandler<ServerModeExceptionThrownEventArgs>(_Wrapper_ExceptionThrown);
					_Wrapper.Apply(_Successful_FilterCriteria, _Successful_sortInfo, _Successful_groupCount, _Successful_summaryInfo, _Successful_totalSummaryInfo);
				}
				return _Wrapper;
			}
		}
		void _Wrapper_InconsistencyDetected(object sender, ServerModeInconsistencyDetectedEventArgs e) {
			if (InconsistencyDetected == null)
				return;
			InconsistencyDetected(this, e);
		}
		void _Wrapper_ExceptionThrown(object sender, ServerModeExceptionThrownEventArgs e) {
			if (ExceptionThrown == null)
				return;
			ExceptionThrown(this, e);
		}
		private IListServer CreateWrapper() {
			if (_IsReadyForTakeOff)
				return CreateRuntimeWrapper();
			else
				return new WcfServerModeDesignTimeWrapper();
		}
		protected virtual IListServer CreateRuntimeWrapper() {
			WcfServerModeCore core = new WcfServerModeCore(_DataSource, _KeyExpression, Extender);
			core.DefaultSorting = _DefaultSorting;
			return core;
		}
		protected void KillWrapper() {
			_Wrapper = null;
		}
		public WcfServerModeFrontEnd(IWcfServerModeFrontEndOwner owner, ServerModeCoreExtender extender) {
			this.Owner = owner;
			this.Extender = extender;
			CatchUp();
		}
		#region IBindingList Members
		void IBindingList.AddIndex(PropertyDescriptor property) {
		}
		object IBindingList.AddNew() {
			if (_IsReadyForTakeOff)
				throw new NotSupportedException();
			else
				return new object();
		}
		bool IBindingList.AllowEdit {
			get { return false; }
		}
		bool IBindingList.AllowNew {
			get { return false; }
		}
		bool IBindingList.AllowRemove {
			get { return false; }
		}
		public void ApplySort(PropertyDescriptor property, ListSortDirection direction) {
			throw new NotImplementedException();
		}
		int IBindingList.Find(PropertyDescriptor property, object key) {
			throw new NotSupportedException();
		}
		bool IBindingList.IsSorted {
			get { return false; }
		}
		public event ListChangedEventHandler ListChanged {
			add { _ListChanged += value; }
			remove { _ListChanged -= value; }
		}
		void IBindingList.RemoveIndex(PropertyDescriptor property) {
		}
		void IBindingList.RemoveSort() {
		}
		ListSortDirection IBindingList.SortDirection {
			get { throw new NotSupportedException(); }
		}
		PropertyDescriptor IBindingList.SortProperty {
			get { throw new NotSupportedException(); }
		}
		bool IBindingList.SupportsChangeNotification {
			get { return true; } 
		}
		bool IBindingList.SupportsSearching {
			get { return false; }
		}
		bool IBindingList.SupportsSorting {
			get { return false; }
		}
		#endregion
		event ListChangedEventHandler _ListChanged;
		protected virtual void OnListChanged(ListChangedEventArgs e) {
			if (_ListChanged != null)
				_ListChanged(this, e);
		}
		#region IListServer Members
		public void Apply(CriteriaOperator filterCriteria, ICollection<ServerModeOrderDescriptor> sortInfo, int groupCount, ICollection<ServerModeSummaryDescriptor> summaryInfo, ICollection<ServerModeSummaryDescriptor> totalSummaryInfo) {
			Wrapper.Apply(filterCriteria, sortInfo, groupCount, summaryInfo, totalSummaryInfo);
			_Successful_FilterCriteria = filterCriteria;
			_Successful_sortInfo = sortInfo;
			_Successful_groupCount = groupCount;
			_Successful_summaryInfo = summaryInfo;
			_Successful_totalSummaryInfo = totalSummaryInfo;
		}
		public int FindIncremental(CriteriaOperator expression, string value, int startIndex, bool searchUp, bool ignoreStartRow, bool allowLoop) {
			return Wrapper.FindIncremental(expression, value, startIndex, searchUp, ignoreStartRow, allowLoop);
		}
		public int LocateByValue(CriteriaOperator expression, object value, int startIndex, bool searchUp) {
            if (value == DBNull.Value) return -1;
			return Wrapper.LocateByValue(expression, value, startIndex, searchUp);
		}
		public List<ListSourceGroupInfo> GetGroupInfo(ListSourceGroupInfo parentGroup) {
			return Wrapper.GetGroupInfo(parentGroup);
		}
		public int GetRowIndexByKey(object key) {
			return Wrapper.GetRowIndexByKey(key);
		}
		public object GetRowKey(int index) {
			return Wrapper.GetRowKey(index);
		}
        public List<object> GetTotalSummary()
        {
			return Wrapper.GetTotalSummary();
		}
		public object[] GetUniqueColumnValues(CriteriaOperator expression, int maxCount, bool includeFilteredOut) {
			return Wrapper.GetUniqueColumnValues(expression, maxCount, includeFilteredOut);
		}
		public virtual IList GetAllFilteredAndSortedRows() {
			return Wrapper.GetAllFilteredAndSortedRows();
		}
		public void Refresh() {
			Wrapper.Refresh();
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}
		#endregion
		#region IList Members
		public int Add(object value) {
			return Wrapper.Add(value);
		}
		public void Clear() {
			Wrapper.Clear();
		}
		public bool Contains(object value) {
			return Wrapper.Contains(value);
		}
		public int IndexOf(object value) {
			return Wrapper.IndexOf(value);
		}
		public void Insert(int index, object value) {
			Wrapper.Insert(index, value);
		}
		public bool IsFixedSize {
			get { return Wrapper.IsFixedSize; }
		}
		public bool IsReadOnly {
			get { return Wrapper.IsReadOnly; }
		}
		public void Remove(object value) {
			Wrapper.Remove(value);
		}
		public void RemoveAt(int index) {
			Wrapper.RemoveAt(index);
		}
		public object this[int index] {
			get {
				return Wrapper[index];
			}
			set {
				Wrapper[index] = value;
				;
			}
		}
		#endregion
		#region ICollection Members
		public void CopyTo(Array array, int index) {
			Wrapper.CopyTo(array, index);
		}
		public int Count {
			get { return Wrapper.Count; }
		}
		public bool IsSynchronized {
			get { return false; }
		}
		public object SyncRoot {
			get { return this; }
		}
		#endregion
		#region IEnumerable Members
		public IEnumerator GetEnumerator() {
			return Wrapper.GetEnumerator();
		}
		#endregion
		#region ITypedList Members
		public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors) {
			return ListBindingHelper.GetListItemProperties(_Type, listAccessors);
		}
		public string GetListName(PropertyDescriptor[] listAccessors) {
			return ListBindingHelper.GetListName(_Type, listAccessors);
		}
		#endregion
		public void CatchUp() {
			bool reset = false, pdreset = false, takeoff = false;
			Type t = Owner.ElementType;
			if (t == null)
				t = typeof(object);
			if (_Type != t) {
				_Type = t;
				pdreset = true;
			}
			if (_DataSource != Owner.Query) {
				_DataSource = Owner.Query;
				reset = true;
			}			
			if (_KeyExpression != Owner.KeyExpression) {
				_KeyExpression = Owner.KeyExpression;
				reset = true;
			}
			if (_DefaultSorting != Owner.DefaultSorting) {
				_DefaultSorting = Owner.DefaultSorting;
				reset = true;
			}
			if (_IsReadyForTakeOff != Owner.IsReadyForTakeOff()) {
				_IsReadyForTakeOff = Owner.IsReadyForTakeOff();
				takeoff = true;
			}
			if (reset || takeoff)
				KillWrapper();
			if (pdreset)
				OnListChanged(new ListChangedEventArgs(ListChangedType.PropertyDescriptorChanged, -1));
			if (reset)
				OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}
		#region IListServerHints Members
		void IListServerHints.HintGridIsPaged(int pageSize) {
			IListServerHints n = Wrapper as IListServerHints;
			if (n == null)
				return;
			n.HintGridIsPaged(pageSize);
		}
		void IListServerHints.HintMaxVisibleRowsInGrid(int rowsInGrid) {
			IListServerHints n = Wrapper as IListServerHints;
			if (n == null)
				return;
			n.HintMaxVisibleRowsInGrid(rowsInGrid);
		}
		#endregion
	}
	public class WcfServerModeDesignTimeWrapper : IListServer {
		#region IListServer Members
		public void Apply(CriteriaOperator filterCriteria, ICollection<ServerModeOrderDescriptor> sortInfo, int groupCount, ICollection<ServerModeSummaryDescriptor> summaryInfo, ICollection<ServerModeSummaryDescriptor> totalSummaryInfo) {
		}
		public void Refresh() { }
		public event EventHandler<ServerModeInconsistencyDetectedEventArgs> InconsistencyDetected { add { } remove { } }
		public event EventHandler<ServerModeExceptionThrownEventArgs> ExceptionThrown { add { } remove { } }
		public object FindKeyByBeginWith(PropertyDescriptor column, string value) {
			return null;
		}
		public object FindKeyByValue(PropertyDescriptor column, object value) {
			return null;
		}
		public int FindIncremental(CriteriaOperator expression, string value, int startIndex, bool searchUp, bool ignoreStartRow, bool allowLoop) {
			return -1;
		}
		public int LocateByValue(CriteriaOperator expression, object value, int startIndex, bool searchUp) {
			return -1;
		}
		public List<ListSourceGroupInfo> GetGroupInfo(ListSourceGroupInfo parentGroup) {
			return new List<ListSourceGroupInfo>();
		}
		public int GetRowIndexByKey(object key) {
			return -1;
		}
		public object GetRowKey(int index) {
			return null;
		}
		public List<object> GetTotalSummary() {
            return new List<object>();
		}
		public object[] GetUniqueColumnValues(CriteriaOperator expression, int maxCount, bool includeFilteredOut) {
			return new object[0];
		}
		public virtual IList GetAllFilteredAndSortedRows() {
			return new object[0];
		}
		#endregion
		#region IList Members
		public int Add(object value) {
			throw new NotSupportedException();
		}
		public void Clear() {
			throw new NotSupportedException();
		}
		public bool Contains(object value) {
			return false;
		}
		public int IndexOf(object value) {
			return -1;
		}
		public void Insert(int index, object value) {
			throw new NotSupportedException();
		}
		public bool IsFixedSize {
			get { return true; }
		}
		public bool IsReadOnly {
			get { return true; }
		}
		public void Remove(object value) {
			throw new NotSupportedException();
		}
		public void RemoveAt(int index) {
			throw new NotSupportedException();
		}
		public object this[int index] {
			get {
				throw new ArgumentOutOfRangeException("index");
			}
			set {
				throw new ArgumentOutOfRangeException("index");
			}
		}
		#endregion
		#region ICollection Members
		public void CopyTo(Array array, int index) {
		}
		public int Count {
			get { return 0; }
		}
		public bool IsSynchronized {
			get { return false; }
		}
		public object SyncRoot {
			get { return this; }
		}
		#endregion
		#region IEnumerable Members
		public IEnumerator GetEnumerator() {
			return new object[0].GetEnumerator();
		}
		#endregion
	}
	public class WcfServerModeCache : ServerModeKeyedCacheExtendable {
		readonly IQueryable source;
		readonly CriteriaOperator externalCriteria;
		public WcfServerModeCache(IQueryable source, CriteriaOperator filterCriteria, CriteriaOperator keyCriteria, ServerModeOrderDescriptor[] sortInfo, int groupCount, ServerModeSummaryDescriptor[] summary, ServerModeSummaryDescriptor[] totalSummary)
			: base(new CriteriaOperator[] { keyCriteria }, sortInfo, groupCount, summary, totalSummary) {
			this.externalCriteria = filterCriteria;
			this.source = source.Where(filterCriteria);
		}
		protected override CriteriaOperator ExternalCriteria {
			get { return externalCriteria; }
		}
		CriteriaOperator SingleKeyCriteria {
			get { return KeysCriteria == null || KeysCriteria.Length == 0 ? null : KeysCriteria[0]; }
		}
		protected override object EvaluateOnInstance(object row, CriteriaOperator criteriaOperator) {
			return CriteriaToQueryableExtender.EvaluateOnInstance(WcfServerModeCore.Converter, source.ElementType, row, criteriaOperator);
		}
		protected override object FetchPrepare(CriteriaOperator where, ServerModeOrderDescriptor[] order) {
			return source.Where(where).OrderBy(order);
		}
		protected override int MagicNumberTakeKeysUpperLimitAfterSkip {
			get { return base.MagicNumberTakeKeysUpperLimitAfterSkip > 1024 ? 1024 : base.MagicNumberTakeKeysUpperLimitAfterSkip; }
		}
		protected override void FetchKeysCore(object source, int skip, int take, out IEnumerable keys, out IEnumerable rows) {
			IQueryable entityQuery = (IQueryable)source;
			if (skip > 0)
				entityQuery = entityQuery.SkipData(skip);
			if(take > 0)
				entityQuery = entityQuery.TakeData(take);
			WrapperResult result = entityQuery.SelectFieldValuesAndRows(SingleKeyCriteria);
			keys = result.FieldList;
			rows = result.ElementList;
		}
		protected override IEnumerable FetchRowsCore(object source, int skip, int take) {
			IQueryable entityQuery = (IQueryable)source;
			if (skip > 0)
				entityQuery = entityQuery.SkipData(skip);
			if (take > 0)
				entityQuery = entityQuery.TakeData(take);
			List<object> result = null;
			foreach (object row in entityQuery) {
				if (result == null) result = new List<object>();
				result.Add(row);
			}
			return result;
		}
		protected override IEnumerable FetchRowsByKeysCore(object[] keys) {
			CriteriaOperator condition = GetFetchRowsByKeysCondition(keys);
			var filtered = source.Where(condition);
			List<object> currentResult = null;
			foreach (object row in filtered) {
				if (currentResult == null) currentResult = new List<object>(keys.Length);
				currentResult.Add(row);
			}
			return currentResult;
		}
		protected override int GetCountInternal(CriteriaOperator criteriaOperator) {
			return source.Where(criteriaOperator).CountOfData();
		}
		protected override Type ResolveKeyType(CriteriaOperator singleKeyCritterion) {
			return source.TakeData(1).SelectFieldValues(singleKeyCritterion).ElementType;
		}
		protected override Type ResolveRowType() {
			return source.ElementType;
		}
		protected override ServerModeGroupInfoData[] PrepareChildrenInternal(CriteriaOperator groupWhere, ServerModeOrderDescriptor groupByDescriptor, ServerModeSummaryDescriptor[] summaries) {
			var sum = source.Where(groupWhere)
							.GroupBy(groupByDescriptor.SortExpression, groupByDescriptor.IsDesc)
							.SelectSummary(source.ElementType, summaries);
			List<ServerModeGroupInfoData> rv = new List<ServerModeGroupInfoData>();
			foreach (IList row in sum) {
				object value = row[0];
				int cnt = (int)row[1];
				object[] summary = new object[summaries.Length];
				for (int i = 0; i < summaries.Length; ++i) {
					summary[i] = row[i + 2];
				}
				rv.Add(new ServerModeGroupInfoData(value, cnt, summary));
			}
			return rv.ToArray();
		}
		protected override ServerModeGroupInfoData PrepareTopGroupInfoInternal(ServerModeSummaryDescriptor[] summaries) {
			var summary = source.GroupBy(new OperandValue(0), false)
								.SelectSummary(source.ElementType, summaries);
			foreach (IList row in summary) {
				int childDataRowCount = (int)row[1];
				object[] totals = new object[summaries.Length];
				for (int i = 0; i < summaries.Length; ++i) {
					totals[i] = row[i + 2];
				}
				return new ServerModeGroupInfoData(null, childDataRowCount, totals);
			}
			return new ServerModeGroupInfoData(null, 0, new object[summaries.Length]);
		}
	}
	internal class SummaryNotSupported {
#if DEBUGTEST
		public override bool Equals(object obj) {
			return obj is SummaryNotSupported;
		}
		public override int GetHashCode() {
			return base.GetHashCode();
		}
#endif
	};
	public static class WcfLinqHelpers {
		static Dictionary<object, Type> wrapperDataTypeCache = new Dictionary<object, Type>();
		static Dictionary<Type, ListHelperBase> listHelperCache = new Dictionary<Type, ListHelperBase>();
		public static IQueryable GroupBy(this IQueryable source, CriteriaOperator groupCriteria, bool isDesc) {
			Type wrapperDataType = GetWrapperDataType(source);
			Type enumerableQueryType = typeof(EnumerableQuery<>).MakeGenericType(wrapperDataType);			
			ListHelperBase listHelper = GetListHelper(wrapperDataType);
			var groups = listHelper.CreateNewList();
			object reflectWrapperData;
			MethodInfo method = wrapperDataType.GetMethod("GroupBy", new Type[] { typeof(CriteriaOperator), typeof(bool) });
			if (enumerableQueryType.IsAssignableFrom(source.GetType())) {
				foreach (object group in source)
					listHelper.Add(groups, (IQueryable)method.Invoke(group, new object[] { groupCriteria, isDesc }));
				return listHelper.AsQueryable(groups);
			}
			if (wrapperDataType.IsAssignableFrom(source.GetType()))
				reflectWrapperData = source;
			else
				reflectWrapperData = GetNewWrapperData(source, wrapperDataType);
			return (IQueryable)method.Invoke(reflectWrapperData, new object[] { groupCriteria, isDesc });
		}
		private static Type GetWrapperDataType(IQueryable source) {
			Type wrapperDataType;
			lock (wrapperDataTypeCache) {
				if (wrapperDataTypeCache.TryGetValue(source, out wrapperDataType))
					return wrapperDataType;
			}
			if (source.ElementType.IsGenericType && source.ElementType.GetGenericTypeDefinition() == typeof(WrapperDataServiceQuery<>)) {
				wrapperDataType = source.ElementType;
			} else {
				wrapperDataType = typeof(WrapperDataServiceQuery<>).MakeGenericType(source.ElementType);
			}
			lock (wrapperDataTypeCache) {
				wrapperDataTypeCache[source] = wrapperDataType;
			}
			return wrapperDataType;
		}
		private static object GetNewWrapperData(IQueryable source, Type wrapperDataType) {
			object[] parametrs = new object[8];
			parametrs[0] = null;
			parametrs[1] = source;
			parametrs[2] = "";
			parametrs[3] = null;
			parametrs[4] = null;
			parametrs[5] = 0;
			parametrs[6] = 0;
			parametrs[7] = 0;
            ConstructorInfo constrInfo = wrapperDataType.GetConstructor(new Type[] { typeof(object), typeof(DataServiceQuery<>).MakeGenericType(source.ElementType), typeof(string), typeof(CriteriaOperator), typeof(CriteriaOperator), typeof(int), typeof(int), typeof(int) });
			object reflectWrapperData = constrInfo.Invoke(parametrs);
			return reflectWrapperData;
		}
		public static readonly object NotSummarySupported = new object();
		public static IEnumerable<object[]> SelectSummary(this IQueryable source, Type sourceType, ServerModeSummaryDescriptor[] summaries) {
			try {
				List<object[]> result = new List<object[]>();
				foreach (object group in source) {
					List<object> aggregateFunclist = new List<object>();
					Type wrapperDataType = typeof(WrapperDataServiceQuery<>).MakeGenericType(sourceType);
					ConstructorInfo constrInfo = wrapperDataType.GetConstructor(new Type[] { wrapperDataType });
					object reflectWrapperData = constrInfo.Invoke(new object[] { group });
					aggregateFunclist.AddPropertyValue(wrapperDataType, reflectWrapperData, "Key");
					aggregateFunclist.AddPropertyValue(wrapperDataType, reflectWrapperData, "Count");
					foreach (ServerModeSummaryDescriptor summary in summaries) {
						switch (summary.SummaryType) {
							case Aggregate.Count:
								aggregateFunclist.AddPropertyValue(wrapperDataType, reflectWrapperData, "Count");
								break;
							case Aggregate.Max:
								aggregateFunclist.AddMethodResultValue(wrapperDataType, reflectWrapperData, summary.SummaryExpression, "Max");
								break;
							case Aggregate.Min:
								aggregateFunclist.AddMethodResultValue(wrapperDataType, reflectWrapperData, summary.SummaryExpression, "Min");
								break;
							default:
								aggregateFunclist.Add(new SummaryNotSupported());
								break;
						}
					}
					result.Add(aggregateFunclist.ToArray());
				}
				return result;
			} catch {
				return null;
			}
		}
		private static void AddMethodResultValue(this List<object> aggregateFunclist, Type wrapperDataType, object reflectWrapperData, CriteriaOperator summary, string methodName) {
			MethodInfo methodAvg = wrapperDataType.GetMethod(methodName, new Type[] { typeof(CriteriaOperator) });
			var avg = methodAvg.Invoke(reflectWrapperData, new object[] { summary });
			aggregateFunclist.Add(avg);
		}
		private static void AddPropertyValue(this List<object> aggregateFunclist, Type wrapperDataType, object reflectWrapperData, string propertyName) {
			PropertyInfo property = wrapperDataType.GetProperty(propertyName);
			var key = property.GetValue(reflectWrapperData, null);
			aggregateFunclist.Add(key);
		}
		public static IQueryable SelectFieldValues(this IQueryable source, CriteriaOperator fieldCriteria) {
			Type wrapperDataType = GetWrapperDataType(source);
			return InvokeMethodWithParamOfTypeCriteriaOperator(source, fieldCriteria, wrapperDataType, "SelectFieldValues");
		}
		public static WrapperResult SelectFieldValuesAndRows(this IQueryable source, CriteriaOperator fieldCriteria) {
			Type wrapperDataType = GetWrapperDataType(source);
			return GetWrapperResult(source, fieldCriteria, wrapperDataType, "SelectFieldValuesAndRows");
		}
		public static IQueryable WhereEq(this IQueryable source, CriteriaOperator fieldNameCriteria, List<CriteriaOperator> criteriaList) {
			Type wrapperDataType = GetWrapperDataType(source);
			MethodInfo method = wrapperDataType.GetMethod("WhereEq", new Type[] { typeof(CriteriaOperator), typeof(List<CriteriaOperator>) });
			object reflectWrapperData;
			Type enumerableQueryType = typeof(EnumerableQuery<>).MakeGenericType(wrapperDataType);
			ListHelperBase listHelper = GetListHelper(wrapperDataType);
			var groups = listHelper.CreateNewList();
			if (enumerableQueryType.IsAssignableFrom(source.GetType())) {
				foreach (object group in source)
					listHelper.Add(groups, (IQueryable)method.Invoke(group, new object[] { fieldNameCriteria, criteriaList }));
				return listHelper.AsQueryable(groups);
			}
			if (wrapperDataType.IsAssignableFrom(source.GetType()))
				reflectWrapperData = source;
			else
				reflectWrapperData = GetNewWrapperData(source, wrapperDataType);
			return (IQueryable)method.Invoke(reflectWrapperData, new object[] { fieldNameCriteria, criteriaList });
		}
		public static IQueryable OrderBy(this IQueryable source, ServerModeOrderDescriptor[] order) {
			Type wrapperDataType = GetWrapperDataType(source);
			object reflectWrapperData;
			MethodInfo method = wrapperDataType.GetMethod("OrderBy", new Type[] { typeof(ServerModeOrderDescriptor[]) });
			Type enumerableQueryType = typeof(EnumerableQuery<>).MakeGenericType(wrapperDataType);
			ListHelperBase listHelper = GetListHelper(wrapperDataType);
			var groups = listHelper.CreateNewList();
			if (enumerableQueryType.IsAssignableFrom(source.GetType())) {
				foreach (object group in source)
					listHelper.Add(groups, (IQueryable)method.Invoke(group, new object[] { order }));
				foreach (ServerModeOrderDescriptor descriptor in order)
					if (CriteriaToString.Convert(null, descriptor.SortExpression) == "Key")
						return listHelper.OrderByKey(WcfServerModeCore.Converter, groups, descriptor);
				return listHelper.AsQueryable(groups);
			}
			if (wrapperDataType.IsAssignableFrom(source.GetType()))
				reflectWrapperData = source;
			else
				reflectWrapperData = GetNewWrapperData(source, wrapperDataType);
			return (IQueryable)method.Invoke(reflectWrapperData, new object[] { order });
		}
		public static IQueryable Where(this IQueryable source, CriteriaOperator filterCriteria) {
			Type wrapperDataType = GetWrapperDataType(source);
			return InvokeMethodWithParamOfTypeCriteriaOperator(source, filterCriteria, wrapperDataType, "Where");
		}
		public static IQueryable SkipData(this IQueryable source, int count) {
			Type wrapperDataType = GetWrapperDataType(source);
			return InvokeMethodWithParamOfTypeInt(source, count, wrapperDataType, "Skip");
		}
		public static IQueryable TakeData(this IQueryable source, int count) {
			Type wrapperDataType = GetWrapperDataType(source);
			return InvokeMethodWithParamOfTypeInt(source, count, wrapperDataType, "Take");
		}
		public abstract class ListHelperBase {
			public abstract void Add(object list, object obj);
			public abstract void AddRange(object list, object range);
			public abstract IQueryable AsQueryable(object list);
			public abstract IQueryable Distinct(object list);
			public abstract IQueryable OrderByKey(ICriteriaToExpressionConverter converter, object list, ServerModeOrderDescriptor descriptor);
			public abstract object CreateNewList();
		}
		public class ListHelper<T> : ListHelperBase {
			public override void Add(object list, object obj) {
				List<T> realList = list as List<T>;
				if (realList != null && obj is T) {
					realList.Add((T)obj);
				}
			}
			public override void AddRange(object list, object range) {
				List<T> realList = list as List<T>;
				if (realList != null && range is IEnumerable<T>) {
					realList.AddRange((IEnumerable<T>)range);
				}
			}
			public override IQueryable AsQueryable(object list) {
				List<T> realList = list as List<T>;
				if (realList == null)
					return null;
				return realList.AsQueryable();
			}
			public override IQueryable Distinct(object list) {
				List<T> realList = list as List<T>;
				if (realList == null)
					return null;
				return realList.Distinct().AsQueryable();
			}
			public override object CreateNewList() {
				return new List<T>();
			}
			IQueryable CreateNewQueryable() {
				return new List<T>().AsQueryable();
			}
			public override IQueryable OrderByKey(ICriteriaToExpressionConverter converter, object list, ServerModeOrderDescriptor descriptor) {
				List<T> realList = list as List<T>;
				if (realList == null)
					return null;
				ParameterExpression thisParameter = Expression.Parameter(typeof(T), "this");
				ParameterExpression predicateParam = Expression.Parameter(typeof(Delegate), "predicate");
				Expression sortExpression = converter.Convert(thisParameter, descriptor.SortExpression);
				var typedPredicate = Expression.Convert(predicateParam, typeof(Func<,>).MakeGenericType(typeof(T), sortExpression.Type));
				Delegate funcSorting = Expression.Lambda(sortExpression, thisParameter).Compile();
				if (descriptor.IsDesc)
					return realList.OrderByDescending((Func<T, object>)funcSorting).AsQueryable();
				else
					return realList.OrderBy((Func<T, object>)funcSorting).AsQueryable();
			}
		}
		private static IQueryable InvokeMethodWithParamOfTypeInt(IQueryable source, int count, Type wrapperDataType, string methodName) {
			Type enumerableQueryType = typeof(EnumerableQuery<>).MakeGenericType(wrapperDataType);
			ListHelperBase listHelper = GetListHelper(wrapperDataType);
			var groups = listHelper.CreateNewList();
			object reflectWrapperData;
			MethodInfo method = wrapperDataType.GetMethod(methodName, new Type[] { typeof(int) });
			if (enumerableQueryType.IsAssignableFrom(source.GetType())) {
				foreach (object group in source)
					listHelper.Add(groups, (IQueryable)method.Invoke(group, new object[] { count }));
				return listHelper.AsQueryable(groups);
			}
			if (wrapperDataType.IsAssignableFrom(source.GetType()))
				reflectWrapperData = source;
			else
				reflectWrapperData = GetNewWrapperData(source, wrapperDataType);
			return (IQueryable)method.Invoke(reflectWrapperData, new object[] { count });
		}
		private static WrapperResult GetWrapperResult(IQueryable source, CriteriaOperator criteriaOp, Type wrapperDataType, string methodName) {
			object reflectWrapperData;
			MethodInfo method = wrapperDataType.GetMethod(methodName, new Type[] { typeof(CriteriaOperator) });
			if (wrapperDataType.IsAssignableFrom(source.GetType()))
				reflectWrapperData = source;
			else
				reflectWrapperData = GetNewWrapperData(source, wrapperDataType);
			return (WrapperResult)method.Invoke(reflectWrapperData, new object[] { criteriaOp });
		}
		private static IQueryable InvokeMethodWithParamOfTypeCriteriaOperator(IQueryable source, CriteriaOperator criteriaOp, Type wrapperDataType, string methodName) {
			Type enumerableQueryType = typeof(EnumerableQuery<>).MakeGenericType(wrapperDataType);
			object reflectWrapperData;
			MethodInfo method = wrapperDataType.GetMethod(methodName, new Type[] { typeof(CriteriaOperator) });
			if (enumerableQueryType.IsAssignableFrom(source.GetType())) {
				Type groupElementType = null;
				ListHelperBase listHelper = null;
				object groups = null;
				foreach (object group in source) {
					IQueryable result = (IQueryable)method.Invoke(group, new object[] { criteriaOp });
					if (groupElementType == null && result != null) {
						groupElementType = result.ElementType;
						listHelper = GetListHelper(groupElementType);
						groups = listHelper.CreateNewList();
					}
					listHelper.AddRange(groups, result);
				}
				return listHelper.AsQueryable(groups);
			}
			if (wrapperDataType.IsAssignableFrom(source.GetType()))
				reflectWrapperData = source;
			else
				reflectWrapperData = GetNewWrapperData(source, wrapperDataType);
			return (IQueryable)method.Invoke(reflectWrapperData, new object[] { criteriaOp });
		}
		private static ListHelperBase GetListHelper(Type wrapperDataType) {
			ListHelperBase listHelper;
			lock (listHelperCache) {
				if (listHelperCache.TryGetValue(wrapperDataType, out listHelper))
					return listHelper;
			}
			Type listHelperType = typeof(ListHelper<>).MakeGenericType(wrapperDataType);
			listHelper = (ListHelperBase)Activator.CreateInstance(listHelperType);
			lock (listHelperCache) {
				listHelperCache[wrapperDataType] = listHelper;
			}
			return listHelper;
		}
		public static int CountOfData(this IQueryable source) {
			PropertyInfo property = GetWrapperDataType(source).GetProperty("Count");
			return (int)property.GetValue(source, null);
		}
	}
	class ElementTypeResolver : CriteriaTypeResolverBase, IClientCriteriaVisitor {
		Dictionary<string, Type> propertiesTypes;
		public ElementTypeResolver(Dictionary<string, Type> propertiesTypes)
			: base() {
			this.propertiesTypes = propertiesTypes;
		}
		public object Visit(JoinOperand theOperand) {
			throw new NotImplementedException();
		}
		public object Visit(OperandProperty theOperand) {
			Type result;
			if (!propertiesTypes.TryGetValue(theOperand.PropertyName, out result)) {
				return new CriteriaTypeResolverResult(typeof(object));
			}
			return new CriteriaTypeResolverResult(result);
		}
		public object Visit(AggregateOperand theOperand) {
			throw new NotImplementedException();
		}
		public Type Resolve(CriteriaOperator criteria) {
			return Process(criteria).Type;
		}
	}
	public class ElementDescriptor : EvaluatorContextDescriptor {
		readonly Dictionary<string, Func<object, object>> expressionDict = new Dictionary<string, Func<object, object>>();
		readonly Dictionary<string, Type> propertiesTypes = new Dictionary<string, Type>();
		readonly ElementTypeResolver typeResolver;
		public ElementDescriptor(Type elementType)
			: base() {
			PropertyInfo[] piList = elementType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo pi in piList) {
				if (!pi.CanRead)
					continue;
				MethodInfo mi = pi.GetGetMethod();
				if (mi == null)
					continue;
				ParameterExpression param = Expression.Parameter(typeof(object));
				Expression<Func<object, object>> expr = Expression.Lambda<Func<object, object>>(Expression.Convert(MethodCallExpression.Call(Expression.Convert(param, elementType), mi), typeof(object)), param);
				expressionDict.Add(pi.Name, expr.Compile());
				propertiesTypes.Add(pi.Name, pi.PropertyType);
			}
			typeResolver = new ElementTypeResolver(propertiesTypes);
		}
		public override object GetPropertyValue(object source, EvaluatorProperty propertyPath) {
			Func<object, object> func;
			if (!expressionDict.TryGetValue(propertyPath.PropertyPath, out func)) {
				throw new InvalidOperationException(propertyPath.PropertyPath);
			}
			return func(source);
		}
		public override EvaluatorContext GetNestedContext(object source, string propertyPath) {
			throw new NotSupportedException();
		}
		public override IEnumerable GetCollectionContexts(object source, string collectionName) {
			throw new NotSupportedException();
		}
		public override IEnumerable GetQueryContexts(object source, string queryTypeName, CriteriaOperator condition) {
			throw new NotSupportedException();
		}
		public Type GetCriteriaType(CriteriaOperator criteria) {
			return typeResolver.Resolve(criteria);
		}
	}
	public struct WrapperResult {
		public IList ElementList;
		public IList FieldList;
		public WrapperResult(IList elementList, IList fieldList) {
			ElementList = elementList;
			FieldList = fieldList;
		}
	}
	public class WrapperDataServiceQuery<TElement> : IQueryable {
		readonly object rootGroupKeyValue;
		readonly DataServiceQuery<TElement> rootSource;
		readonly CriteriaOperator rootKeyExpression;
		readonly string rootOrderByQuery;
        readonly CriteriaOperator rootFilterQuery;
		readonly int rootLevel;
		readonly int rootTakeCount;
		readonly int rootSkipCount;
		readonly ElementDescriptor elementDescriptor;
		public int Count {
			get {
				DataServiceQuery<TElement> query = Rows.IncludeTotalCount().Take(1) as DataServiceQuery<TElement>;
#if !SL

				QueryOperationResponse<TElement> response = query.Execute() as QueryOperationResponse<TElement>;
#else
				QueryOperationResponse<TElement> response = query.ExecuteAsync() as QueryOperationResponse<TElement>;
#endif
				if (response == null) return 0;
				return (int)response.TotalCount;
			}
		}
        public WrapperDataServiceQuery(object rootGroupKeyValue, DataServiceQuery<TElement> rootSource, string rootOrderByQuery, CriteriaOperator rootFilterQuery, CriteriaOperator rootKeyExpression,
									   int rootLevel, int rootTakeCount, int rootSkipCount) {
			this.rootGroupKeyValue = rootGroupKeyValue;
			this.rootSource = rootSource;
			this.rootOrderByQuery = rootOrderByQuery;
			this.rootFilterQuery = rootFilterQuery;
			this.rootKeyExpression = rootKeyExpression;
			this.rootLevel = rootLevel;
			this.rootTakeCount = rootTakeCount;
			this.rootSkipCount = rootSkipCount;
			this.elementDescriptor = new ElementDescriptor(typeof(TElement));
		}
        public WrapperDataServiceQuery(object rootGroupKeyValue, DataServiceQuery<TElement> rootSource, string rootOrderByQuery, CriteriaOperator rootFilterQuery, CriteriaOperator rootKeyExpression,
									   int rootLevel, int rootTakeCount, int rootSkipCount, ElementDescriptor elementDescriptor) {
			this.rootGroupKeyValue = rootGroupKeyValue;
			this.rootSource = rootSource;
			this.rootOrderByQuery = rootOrderByQuery;
			this.rootFilterQuery = rootFilterQuery;
			this.rootKeyExpression = rootKeyExpression;
			this.rootLevel = rootLevel;
			this.rootTakeCount = rootTakeCount;
			this.rootSkipCount = rootSkipCount;
			this.elementDescriptor = elementDescriptor;
		}
		public WrapperDataServiceQuery(WrapperDataServiceQuery<TElement> source)
			: this(source.rootGroupKeyValue, source.rootSource, source.rootOrderByQuery, source.rootFilterQuery, source.rootKeyExpression, source.rootLevel, source.rootTakeCount,
					source.rootSkipCount, source.elementDescriptor) {
		}
		public object Key {
			get { return rootGroupKeyValue; }
		}
		public DataServiceQuery<TElement> Rows {
			get {
				DataServiceQuery<TElement> tempSource = rootSource;
				if (!string.IsNullOrEmpty(rootOrderByQuery))
					tempSource = tempSource.AddQueryOption("$orderby", rootOrderByQuery);
                if (rootFilterQuery != null)
                {
                    tempSource = DataServiceQueryTranslator.Translate(tempSource, rootFilterQuery);
                }
			    if (rootSkipCount != 0)
					tempSource = tempSource.Skip(rootSkipCount) as DataServiceQuery<TElement>;
				if (rootTakeCount != 0)
					tempSource = tempSource.Take(rootTakeCount) as DataServiceQuery<TElement>;
				return tempSource;
			}
		}
		public IQueryable GroupBy(CriteriaOperator key, bool isDesc) {
			List<WrapperDataServiceQuery<TElement>> result = new List<WrapperDataServiceQuery<TElement>>();
            CriteriaOperator filterQuery;
			string orderbyQuery = CriteriaToString.Convert<TElement>(key);
			if (isDesc)
				orderbyQuery += " desc";
			int timeoutCounter = 0;
			TimeSpan timeout = ServerModeCommonParameters.ComplexGroupingOperationTimeoutTimeSpan;
			DateTime start = DateTime.UtcNow;
			object firstBoolValue = null;
			int isBoolValueCounter = 0;
			var tempSource = rootSource.AddQueryOption("$orderby", orderbyQuery);
			object keyValue = null;
			var keys = SelectUniqueFieldValues(tempSource, key, "", rootFilterQuery, rootSkipCount, 1);
			if(ReferenceEquals(keys, null))
				return result.AsQueryable();
			foreach (object obj in keys)
				keyValue = obj;
			WrapperDataServiceQuery<TElement> nullGroup = null;
			if (keyValue == null) {
				filterQuery = GetFilterQuery(key, keyValue, BinaryOperatorType.Equal);
				nullGroup = new WrapperDataServiceQuery<TElement>(null, rootSource, "", filterQuery, key, rootLevel + 1, rootTakeCount, rootSkipCount, elementDescriptor);
				if (!isDesc) result.Add(nullGroup);
				filterQuery = GetFilterQuery(key, keyValue, BinaryOperatorType.NotEqual);
				keys = SelectUniqueFieldValues(tempSource, key, "", filterQuery, rootSkipCount, 1);
				if (ReferenceEquals(keys, null)) {
					result.Add(nullGroup);
					return result.AsQueryable();
				}
				foreach (object obj in keys)
					keyValue = obj;
			} else {
				if (keyValue.GetType() == typeof(bool) || keyValue.GetType() == typeof(bool?)) {
					isBoolValueCounter++;
					firstBoolValue = keyValue;
				}
				filterQuery = GetFilterQuery(key, null, BinaryOperatorType.Equal);
				var nullKeys = SelectUniqueFieldValues(tempSource, key, "", filterQuery, rootSkipCount, 1);
				if (!ReferenceEquals(nullKeys, null)) {
					nullGroup = new WrapperDataServiceQuery<TElement>(null, rootSource, "", filterQuery, key, rootLevel + 1, rootTakeCount, rootSkipCount, elementDescriptor);
					if(!isDesc)result.Add(nullGroup);
				}
			}
			if ((DateTime.UtcNow - start) > timeout) throw new TimeoutException(); 
			filterQuery = GetFilterQuery(key, keyValue, BinaryOperatorType.Equal);
			result.Add(new WrapperDataServiceQuery<TElement>(keyValue, rootSource, "", filterQuery, key, rootLevel + 1, rootTakeCount, rootSkipCount, elementDescriptor));
			do {
				if (isBoolValueCounter > 0) {
					if (isBoolValueCounter == 1) {
						filterQuery = GetFilterQuery(key, !((bool)firstBoolValue), BinaryOperatorType.Equal);
					} else
						break;
					isBoolValueCounter++;
				} else {
					filterQuery = GetFilterQuery(key, keyValue, isDesc ? BinaryOperatorType.Less : BinaryOperatorType.Greater);
				}
				keys = SelectUniqueFieldValues(tempSource, key, "", filterQuery, 0, 1);
				if (ReferenceEquals(keys, null))
					break;
				object prevKeyValue = keyValue;
				keyValue = null;
				foreach (object obj in keys)
					keyValue = obj;
				if (keyValue == null) break;
				if (object.Equals(keyValue, prevKeyValue)) throw new InvalidOperationException();
				if (isBoolValueCounter == 0 && (keyValue.GetType() == typeof(bool) || keyValue.GetType() == typeof(bool?))) {
					firstBoolValue = keyValue;
					isBoolValueCounter++;
				}
				filterQuery = GetFilterQuery(key, keyValue, BinaryOperatorType.Equal);
				result.Add(new WrapperDataServiceQuery<TElement>(keyValue, rootSource, "", filterQuery, key, rootLevel + 1, rootTakeCount, rootSkipCount, elementDescriptor));
				timeoutCounter++;
				if (timeoutCounter == Int32.MaxValue) {
					timeoutCounter = 0;
				}
				if ((timeoutCounter % 3) == 0 && (DateTime.UtcNow - start) > timeout) throw new TimeoutException(); 
			} while (true);
			if (isDesc && nullGroup != null) result.Add(nullGroup);
			return result.AsQueryable();
		}
		private static WcfLinqHelpers.ListHelperBase GetListHelper(Type type) {
			Type listHelperType = typeof(DevExpress.Data.WcfLinq.Helpers.WcfLinqHelpers.ListHelper<>).MakeGenericType(type);
			return (WcfLinqHelpers.ListHelperBase)Activator.CreateInstance(listHelperType);
		}
		public IQueryable SelectFieldValues(CriteriaOperator criteria) {
			Type propertyType = elementDescriptor.GetCriteriaType(CriteriaToString.Convert<TElement>(criteria) == "Key" ? rootKeyExpression : criteria);
			WcfLinqHelpers.ListHelperBase listHelper = GetListHelper(propertyType);
			return listHelper.AsQueryable(SelectFieldValuesAsList(rootSource, criteria, rootOrderByQuery, rootFilterQuery, rootSkipCount, rootTakeCount).FieldList);
		}
		public WrapperResult SelectFieldValuesAndRows(CriteriaOperator criteria) {
			Type propertyType = elementDescriptor.GetCriteriaType(CriteriaToString.Convert<TElement>(criteria) == "Key" ? rootKeyExpression : criteria);
			WcfLinqHelpers.ListHelperBase listHelper = GetListHelper(propertyType);
			return SelectFieldValuesAsList(rootSource, criteria, rootOrderByQuery, rootFilterQuery, rootSkipCount, rootTakeCount);
		}
		private static WcfLinqHelpers.ListHelperBase GetNewListHelper(string fieldName) {
			PropertyInfo propInfo = typeof(TElement).GetProperty(fieldName);
			return GetListHelper(propInfo.PropertyType);
		}
		private static WcfLinqHelpers.ListHelperBase GetNewListHelper(Type fieldType) {
			return GetListHelper(fieldType);
		}
        private IQueryable SelectUniqueFieldValues(DataServiceQuery<TElement> source, CriteriaOperator criteria, string orderByQuery, CriteriaOperator filterQuery, int skipCount, int takeCount)
        {
			Type propertyType = elementDescriptor.GetCriteriaType(CriteriaToString.Convert<TElement>(criteria) == "Key" ? rootKeyExpression : criteria);
			WcfLinqHelpers.ListHelperBase listHelper = GetListHelper(propertyType);
			return listHelper.Distinct(SelectFieldValuesAsList(source, criteria, orderByQuery, filterQuery, skipCount, takeCount).FieldList);
		}
        private WrapperResult SelectFieldValuesAsList(DataServiceQuery<TElement> source, CriteriaOperator criteria, string orderByQuery, CriteriaOperator filterQuery, int skipCount, int takeCount)
        {
			try {				
				object values;
				DataServiceQuery<TElement> tempSource = source;
				if (CriteriaToString.Convert<TElement>(criteria) == "Key") {
					Type propertyType = elementDescriptor.GetCriteriaType(rootKeyExpression);
					DevExpress.Data.WcfLinq.Helpers.WcfLinqHelpers.ListHelperBase listHelper = GetListHelper(propertyType);
					values = listHelper.CreateNewList();
					listHelper.Add(values, rootGroupKeyValue);
					return new WrapperResult(null, (IList)values);
				} else {
					if (!string.IsNullOrEmpty(orderByQuery))
						tempSource = tempSource.AddQueryOption("$orderby", orderByQuery);
                    if (filterQuery != null)
                    {
                        tempSource = DataServiceQueryTranslator.Translate(tempSource, filterQuery);
                    }
				    if (skipCount != 0)
						tempSource = tempSource.Skip(skipCount) as DataServiceQuery<TElement>;
					if (takeCount != 0)
						tempSource = tempSource.Take(takeCount) as DataServiceQuery<TElement>;
#if !SL
					List<TElement> list = tempSource.ToList();
#else
					List<TElement> list = tempSource.ExecuteAsync().ToList();
#endif
					if (list.Count == 0)
						return new WrapperResult(null, null);
					Type propertyType = elementDescriptor.GetCriteriaType(criteria);
					DevExpress.Data.WcfLinq.Helpers.WcfLinqHelpers.ListHelperBase listHelper = GetListHelper(propertyType);
					values = listHelper.CreateNewList();
					ExpressionEvaluator evaluator = new ExpressionEvaluator(elementDescriptor, criteria);
					for (int i = 0; i < list.Count; i++)
						listHelper.Add(values, evaluator.Evaluate(list[i]));
					return new WrapperResult(list, (IList)values);
				}
			} catch (Exception) { }
			return new WrapperResult(null, null);
		}
		private string GetOrderByQuery(string orderbyQuery, string fieldName, bool desc) {
			if (string.IsNullOrEmpty(orderbyQuery))
				orderbyQuery += fieldName;
			else
				orderbyQuery += "," + fieldName;
			if (desc)
				orderbyQuery += " desc";
			return orderbyQuery;
		}
		private CriteriaOperator GetFilterQuery(CriteriaOperator keyCriteria, object keyValue, BinaryOperatorType opType) {
            var criteria = new BinaryOperator(keyCriteria, new OperandValue(keyValue), opType);
		    var filter = CriteriaForFilter.Prepare(criteria);
            if (rootFilterQuery == null)
            {
				return filter;
			}
		    return CriteriaForFilter.Prepare(criteria & rootFilterQuery);
		}
		public object Max(CriteriaOperator fieldCriteria) {
			return MaxOrMin(fieldCriteria, true);
		}
		public object Min(CriteriaOperator fieldCriteria) {
			return MaxOrMin(fieldCriteria, false);
		}
		private object MaxOrMin(CriteriaOperator fieldCriteria, bool isMax) {
			string fieldName = CriteriaToString.Convert<TElement>(fieldCriteria);
			DataServiceQuery<TElement> tempSource = rootSource;
			string orderbyQuery = fieldName;
			if (isMax == true)
				orderbyQuery += " desc";
			DataServiceQuery<TElement> query = tempSource.AddQueryOption("$orderby", orderbyQuery)
							  .AddQueryOption("$filter", rootFilterQuery)
							  .Take(1) as DataServiceQuery<TElement>;
#if !SL
			IQueryable newSource = query.Execute().AsQueryable();
#else
			IQueryable newSource = query.ExecuteAsync().AsQueryable();
#endif
			object result = 0;
			foreach (object number in newSource.MakeSelect(WcfServerModeCore.Converter, new OperandProperty(fieldName)))
				result = number;
			return result;
		}
		public IQueryable OrderBy(ServerModeOrderDescriptor[] order) {
			DataServiceQuery<TElement> tempSource = rootSource;
			string fieldName;
			string orderbyQuery = rootOrderByQuery;
			foreach (ServerModeOrderDescriptor descriptor in order) {
				fieldName = CriteriaToString.Convert<TElement>(descriptor.SortExpression);
				if (fieldName != "Key")
					orderbyQuery = GetOrderByQuery(orderbyQuery, fieldName, descriptor.IsDesc);
			}
			return new WrapperDataServiceQuery<TElement>(rootGroupKeyValue, rootSource, orderbyQuery, rootFilterQuery, rootKeyExpression, rootLevel, rootTakeCount, rootSkipCount, elementDescriptor);
		}
		public IQueryable Where(CriteriaOperator filterCriteria)
		{
		    CriteriaOperator filterQuery = null;
			//string strFilterCriteria = CriteriaToString.Convert<TElement>(CriteriaForFilter.Prepare(filterCriteria));
            if (filterCriteria!=null)
            {
                if (rootFilterQuery != null)
                    filterQuery = CriteriaForFilter.Prepare(filterCriteria & rootFilterQuery);
                else
                    filterQuery = CriteriaForFilter.Prepare(filterCriteria);
			} else {
                filterQuery = CriteriaForFilter.Prepare(rootFilterQuery);
			}
			return new WrapperDataServiceQuery<TElement>(rootGroupKeyValue, rootSource, rootOrderByQuery, filterQuery, rootKeyExpression, rootLevel, rootTakeCount, rootSkipCount, elementDescriptor);
		}
		public IQueryable Take(int count) {
			return new WrapperDataServiceQuery<TElement>(rootGroupKeyValue, rootSource, rootOrderByQuery, rootFilterQuery, rootKeyExpression, rootLevel, count, rootSkipCount, elementDescriptor);
		}
		public IQueryable Skip(int count) {
			return new WrapperDataServiceQuery<TElement>(rootGroupKeyValue, rootSource, rootOrderByQuery, rootFilterQuery, rootKeyExpression, rootLevel, rootTakeCount, count, elementDescriptor);
		}
		public Type ElementType {
			get { return typeof(TElement); }
		}
		public Expression Expression {
			get { throw new NotImplementedException(); }
		}
		public IQueryProvider Provider {
			get { throw new NotImplementedException(); }
		}
		IEnumerator IEnumerable.GetEnumerator() {
			return (IEnumerator)GetEnumerator();
		}
		public EnumeratorForWrapperDataServiceQuery<TElement> GetEnumerator() {
			return new EnumeratorForWrapperDataServiceQuery<TElement>(rootSource, rootOrderByQuery, rootFilterQuery, rootTakeCount, rootSkipCount);
		}
	}
	public class CriteriaForFilter : ClientCriteriaVisitorBase {
		public static CriteriaOperator Prepare(CriteriaOperator criteria) {
			return new CriteriaForFilter().Process(criteria);
		}
		protected override object Visit(BinaryOperator theOperator) {
			if (theOperator.OperatorType == BinaryOperatorType.Equal || theOperator.OperatorType == BinaryOperatorType.NotEqual) {
				if ((theOperator.LeftOperand is OperandValue) && (((OperandValue)theOperator.LeftOperand).Value == null)
					|| (theOperator.RightOperand is OperandValue) && (((OperandValue)theOperator.RightOperand).Value == null)) {
					inIsNull++;
					try {
						return new BinaryOperator(Process(theOperator.LeftOperand), Process(theOperator.RightOperand), theOperator.OperatorType);
					} finally {
						inIsNull--;
					}					
				}
			}
			CriteriaOperator leftResult = Process(theOperator.LeftOperand);
			CriteriaOperator rightResult = Process(theOperator.RightOperand);
			CriteriaOperator result = null;
			result = CheckGetDateFunction(theOperator, leftResult, rightResult);
			if (ReferenceEquals(result, null)) {
				result = CheckGetDateFunction(theOperator, rightResult, leftResult);
			}
			if (ReferenceEquals(result, null)) {
				return base.Visit(theOperator);
			}
			return result;
		}
		int inIsNull = 0;
		protected override object Visit(FunctionOperator theOperator) {
			if (theOperator.OperatorType == FunctionOperatorType.IsNull || theOperator.OperatorType == FunctionOperatorType.IsNullOrEmpty) {
				inIsNull++;
				try {
					CriteriaOperatorCollection results = new CriteriaOperatorCollection();
					foreach (CriteriaOperator operand in theOperator.Operands) {
						results.Add(Process(operand));
					}
					return new FunctionOperator(theOperator.OperatorType, results);
				} finally {
					inIsNull--;
				}
			}
			if (theOperator.OperatorType == FunctionOperatorType.GetDate) {
				if (inIsNull > 0) {
					return theOperator.Operands.Count == 0 ? null : theOperator.Operands[0];
				}
			}
			return base.Visit(theOperator);
		}
		protected override object Visit(UnaryOperator theOperator) {
			if (theOperator.OperatorType == UnaryOperatorType.IsNull) {
				inIsNull++;
				try {
					return new UnaryOperator(theOperator.OperatorType, Process(theOperator.Operand));
				} finally {
					inIsNull--;
				}
			}
			return base.Visit(theOperator);
		}
		private CriteriaOperator CheckGetDateFunction(BinaryOperator theOperator, CriteriaOperator leftResult, CriteriaOperator rightResult) {
			CriteriaOperator result = null;
			if (leftResult is FunctionOperator) {
				BinaryOperatorType operatorType;
				switch (theOperator.OperatorType) {
					case BinaryOperatorType.Greater:
						operatorType = BinaryOperatorType.GreaterOrEqual;
						break;
					case BinaryOperatorType.Less:
						operatorType = BinaryOperatorType.LessOrEqual;
						break;
					default:
						operatorType = theOperator.OperatorType;
						break;
				}
				FunctionOperator leftOperand = (FunctionOperator)leftResult;
				if (leftOperand.OperatorType == FunctionOperatorType.GetDate) {
					GroupOperatorType groupType = theOperator.OperatorType == BinaryOperatorType.NotEqual ? GroupOperatorType.Or : GroupOperatorType.And;
					if (rightResult is OperandValue) {
						OperandValue rightOperand = (OperandValue)rightResult;
						if (rightOperand.Value is DateTime) {
							DateTime rightOperandDate = (DateTime)rightOperand.Value;
							if (operatorType == theOperator.OperatorType) {
								result = Process(new GroupOperator(groupType,
									new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Year), operatorType),
									new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetMonth, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Month), operatorType),
									new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetDay, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Day), theOperator.OperatorType)));
							} else {
								result = Process(GroupOperator.Or(
									GroupOperator.And(new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Year), operatorType),
									new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetMonth, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Month), operatorType),
									new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetDay, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Day), theOperator.OperatorType))
									,GroupOperator.And(new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Year), operatorType),
									new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetMonth, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Month), theOperator.OperatorType))
									, new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]), new OperandValue(rightOperandDate.Year), theOperator.OperatorType)));
							}
						}
					} else {
						if (operatorType == theOperator.OperatorType) {
							result = Process(new GroupOperator(groupType,
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetYear, rightResult), operatorType),
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetMonth, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetMonth, rightResult), operatorType),
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetDay, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetDay, rightResult), theOperator.OperatorType)));
						} else {
							result = Process(GroupOperator.Or(
								GroupOperator.And(
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetYear, rightResult), operatorType),
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetMonth, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetMonth, rightResult), operatorType),
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetDay, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetDay, rightResult), theOperator.OperatorType))
									,
								GroupOperator.And(
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetYear, rightResult), operatorType),
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetMonth, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetMonth, rightResult), theOperator.OperatorType))
									,
								new BinaryOperator(new FunctionOperator(FunctionOperatorType.GetYear, leftOperand.Operands[0]),
									new FunctionOperator(FunctionOperatorType.GetYear, rightResult), theOperator.OperatorType)
									));
						}
					}
				}
			}
			return result;
		}
	}
	public class CriteriaToString : IClientCriteriaVisitor {
		readonly Type elementType;
		readonly ElementDescriptor elementDescriptor;
		static Dictionary<char, string> escapeDict = new Dictionary<char, string>();
		static CriteriaToString() {
			escapeDict.Add('\'', "''");
			escapeDict.Add('%', "%25");
			escapeDict.Add('#', "%23");
			escapeDict.Add('&', "%26");
			escapeDict.Add('!', "%21");
			escapeDict.Add('+', "%2B");
		}
		public CriteriaToString(Type elementType) {
			this.elementType = elementType;
			this.elementDescriptor = new ElementDescriptor(elementType);
		}
		public string Process(CriteriaOperator criteria) {
			if (ReferenceEquals(criteria, null))
				return null;
			return (string)criteria.Accept(this);
		}
		public static string Convert(Type elementType, CriteriaOperator criteria) {
			return new CriteriaToString(elementType).Process(criteria);
		}
		public static string Convert<T>(CriteriaOperator criteria) {
			return Convert(typeof(T), criteria);
		}
		public object Visit(JoinOperand theOperand) {
			throw new NotSupportedException("This operation is not supported!");
		}
		object IClientCriteriaVisitor.Visit(OperandProperty theOperand) {
			return string.IsNullOrEmpty(theOperand.PropertyName) ? theOperand.PropertyName : theOperand.PropertyName.Replace('.', '/');
		}
		public object Visit(AggregateOperand theOperand) {
			throw new NotImplementedException();
		}
		public object Visit(FunctionOperator theOperator) {
			string format = string.Empty;
			switch (theOperator.OperatorType) {
				case FunctionOperatorType.Contains:
					format = "substringof({1},{0})";
					break;
				case FunctionOperatorType.StartsWith:
					format = "startswith({0},{1})";
					break;
				case FunctionOperatorType.EndsWith:
					format = "endswith({0},{1})";
					break;
				case FunctionOperatorType.Substring:
					if (theOperator.Operands.Count == 2)
						format = "substring({0},{1})";
					else
						format = "substring({0},{1},{2})";
					break;
				case FunctionOperatorType.Concat:
					format = "concat({0},{1})";
					break;
				case FunctionOperatorType.Upper:
					format = "toupper({0})";
					break;
				case FunctionOperatorType.Lower:
					format = "tolower({0})";
					break;
				case FunctionOperatorType.Trim:
					format = "trim({0})";
					break;
				case FunctionOperatorType.Replace:
					format = "replace({0},{1},{2})";
					break;
				case FunctionOperatorType.GetDay:
					format = "day({0})";
					break;
				case FunctionOperatorType.GetHour:
					format = "hour({0})";
					break;
				case FunctionOperatorType.GetMinute:
					format = "minute({0})";
					break;
				case FunctionOperatorType.GetMonth:
					format = "month({0})";
					break;
				case FunctionOperatorType.GetSecond:
					format = "second({0})";
					break;
				case FunctionOperatorType.GetYear:
					format = "year({0})";
					break;
				case FunctionOperatorType.GetDate:
					format = "year({0}),month({0}),day({0})";
					break;						
				case FunctionOperatorType.Round:
					format = "round({0})";
					break;
				case FunctionOperatorType.Floor:
					format = "floor({0})";
					break;
				case FunctionOperatorType.Ceiling:
					format = "ceiling({0})";
					break;
				default:
					throw new NotSupportedException("This operation is not supported!");
			}
			switch (theOperator.Operands.Count) {
				case 1: {
						string left = Process(theOperator.Operands[0]);
						return string.Format(format, left);
					}
				case 2: {
						string left = Process(theOperator.Operands[0]);
						string right = Process(theOperator.Operands[1]);
						return string.Format(format, left, right);
					}
				case 3: {
						string first = Process(theOperator.Operands[0]);
						string second = Process(theOperator.Operands[1]);
						string third = Process(theOperator.Operands[2]);
						return string.Format(format, first, second, third);
					}
				default:
					throw new NotSupportedException("This operation is not supported!");
			}
		}
		static string EscapeString(string str) {
			if (str == null) return str;
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < str.Length; i++) {
				char c = str[i];
				string escapeString;
				if (escapeDict.TryGetValue(c, out escapeString)) {
					result.Append(escapeString);
				} else {
					result.Append(c);
				}
			}
			return result.ToString();
		}
		public object Visit(OperandValue theOperand) {
			if (theOperand.Value == null) return "null";
			Type valueType = theOperand.Value.GetType();
			switch (Type.GetTypeCode(valueType)) {
				case TypeCode.Boolean:
					return ((bool)theOperand.Value) ? "true" : "false";
				case TypeCode.DateTime: {
						DateTime dt = ((DateTime)theOperand.Value);
						StringBuilder sb = new StringBuilder(45);
						sb.Append("datetime'");
						sb.Append(dt.ToString("yyyy-MM-ddTHH:mm:ss"));
						if (dt.Millisecond > 0) sb.Append(dt.ToString(".ffffzzz"));
						sb.Append("'");
						return sb.ToString();
					}
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.SByte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					return ((IConvertible)theOperand.Value).ToString(CultureInfo.InvariantCulture);
				case TypeCode.Single:
					return string.Concat(((float)theOperand.Value).ToString("F", CultureInfo.InvariantCulture), "f");
				case TypeCode.Double:
					return string.Concat(((double)theOperand.Value).ToString("F", CultureInfo.InvariantCulture), "d");
				case TypeCode.Decimal:
					return string.Concat(((decimal)theOperand.Value).ToString("G", CultureInfo.InvariantCulture), "m");
				case TypeCode.String:
					return "'" + EscapeString(((string)(theOperand.Value))) + "'";
				case TypeCode.Object:
					if (valueType == typeof(Guid)) {
						return string.Format("guid'{0:D}'", theOperand.Value);
					}
					break;
			}
			return EscapeString(theOperand.Value.ToString());
		}
		public object Visit(GroupOperator theOperator) {
			StringBuilder result = new StringBuilder();
			if (theOperator.Operands.Count > 0) {
				result.Append("(");
			}
			for (int i = 0; i < theOperator.Operands.Count; i++) {
				if (i > 0) {
					result.Append(" ");
					result.Append(theOperator.OperatorType.ToString().ToLower());
					result.Append(" ");
				}
				result.Append(" (");
				result.Append(Process(theOperator.Operands[i]));
				result.Append(") ");
			}
			if (theOperator.Operands.Count > 0) {
				result.Append(")");
			}
			return result.ToString();
		}
		public object Visit(InOperator theOperator) {
			bool leftIsDecimal = false;
			Type leftType = elementDescriptor.GetCriteriaType(theOperator.LeftOperand);
			Type leftTypeU = Nullable.GetUnderlyingType(leftType);
			leftType = leftTypeU == null ? leftType : leftTypeU;
			leftIsDecimal = leftType == typeof(decimal);
			string property = Process(theOperator.LeftOperand);
			StringBuilder result = new StringBuilder();
			if (theOperator.Operands.Count > 0) {
				result.Append("(");
			}
			for (int i = 0; i < theOperator.Operands.Count; i++) {
				if (i > 0) {
					result.Append(" or ");
				}
				result.Append(" (");
				CriteriaOperator rightOperand = theOperator.Operands[i];
				if (leftIsDecimal) {
					Type rightType = elementDescriptor.GetCriteriaType(rightOperand);
					Type rightTypeU = Nullable.GetUnderlyingType(rightType);
					rightType = rightTypeU == null ? rightType : rightTypeU;
					if(leftType != rightType){
						OperandValue operandValue = rightOperand as OperandValue;
						if (!ReferenceEquals(operandValue, null)) {
							if (operandValue.Value != null) {
								rightOperand = new OperandValue(((IConvertible)operandValue.Value).ToDecimal(CultureInfo.InvariantCulture));
							}
						} 
					}
				}
				result.Append(property + " eq " + Process(rightOperand));
				result.Append(") ");
			}
			if (theOperator.Operands.Count > 0) {
				result.Append(")");
			}
			return result.ToString();
		}
		public object Visit(UnaryOperator theOperator) {
			string operand = Process(theOperator.Operand);
			string format = string.Empty;
			switch (theOperator.OperatorType) {
				case UnaryOperatorType.IsNull:
					format = "{0} eq null";
					break;
				case UnaryOperatorType.Not:
					format = "not ({0})";
					break;
			}
			return string.Format(format, operand);
		}
		object ICriteriaVisitor.Visit(BinaryOperator theOperator) {
			CriteriaOperator leftOperand = theOperator.LeftOperand;
			CriteriaOperator rightOperand = theOperator.RightOperand;
			Type leftType = elementDescriptor.GetCriteriaType(theOperator.LeftOperand);
			Type rightType = elementDescriptor.GetCriteriaType(theOperator.RightOperand);
			Type leftTypeU = Nullable.GetUnderlyingType(leftType);
			Type rightTypeU = Nullable.GetUnderlyingType(rightType);
			leftType = leftTypeU == null ? leftType : leftTypeU;
			rightType = rightTypeU == null ? rightType : rightTypeU;
			if (leftType != rightType) {
				if (leftType == typeof(decimal)) {
					OperandValue operandValue= rightOperand as OperandValue;
					if (!ReferenceEquals(operandValue, null)) {
						if (operandValue.Value != null) {
							rightOperand = new OperandValue(((IConvertible)operandValue.Value).ToDecimal(CultureInfo.InvariantCulture));
						}
					} 
				} else if (rightType == typeof(decimal)) {
					OperandValue operandValue = leftOperand as OperandValue;
					if (!ReferenceEquals(operandValue, null)) {
						if (operandValue.Value != null) {
							leftOperand = new OperandValue(((IConvertible)operandValue.Value).ToDecimal(CultureInfo.InvariantCulture));
						}
					} 
				}
			}
			string left = Process(leftOperand);
			string right = Process(rightOperand);
			string format = string.Empty;
			switch (theOperator.OperatorType) {
				case BinaryOperatorType.Equal:
					format = "{0} eq {1}";
					break;
				case BinaryOperatorType.NotEqual:
					format = "{0} ne {1}";
					break;
				case BinaryOperatorType.Greater:
					format = "{0} gt {1}";
					break;
				case BinaryOperatorType.Less:
					format = "{0} lt {1}";
					break;
				case BinaryOperatorType.LessOrEqual:
					format = "{0} le {1}";
					break;
				case BinaryOperatorType.GreaterOrEqual:
					format = "{0} ge {1}";
					break;
				default:
					throw new NotSupportedException("This operation is not supported!");
			}
			return string.Format(format, left, right);
		}
		public object Visit(BetweenOperator theOperator) {
			string begin = Process(theOperator.BeginExpression);
			string end = Process(theOperator.EndExpression);
			string property = Process(theOperator.TestExpression);
			string format = "{0} ge {1} and {0} le {2}";
			return string.Format(format, property, begin, end);
		}
	}
	public class EnumeratorForWrapperDataServiceQuery<TElement> : IEnumerator {
		int position = -1;
		int count;
		TElement[] data;
        public EnumeratorForWrapperDataServiceQuery(DataServiceQuery<TElement> source, string rootOrderByQuery, CriteriaOperator rootFilterQuery, int count, int rootSkipCount)
        {
            DataServiceQuery<TElement> tempSource = source;
			if (!string.IsNullOrEmpty(rootOrderByQuery))
                tempSource = tempSource.AddQueryOption("$orderby", rootOrderByQuery);
            if (rootFilterQuery != null)
            {
                tempSource = DataServiceQueryTranslator.Translate(tempSource, rootFilterQuery);
            }
            if (count > 0)
                tempSource = tempSource.Take(count) as DataServiceQuery<TElement>;
			if (rootSkipCount > 0)
                tempSource = tempSource.Skip(rootSkipCount) as DataServiceQuery<TElement>;
#if !SL
			data = tempSource.ToArray();
#else
			data = tempSource.ExecuteAsync().ToArray();
#endif
			this.count = data.Length;
		}
		object IEnumerator.Current {
			get { return Current; }
		}
		public bool MoveNext() {
			position++;
			return (position < count);
		}
		public void Reset() {
			position = -1;
		}
		public TElement Current {
			get {
				try {
					return data[position];
				} catch (IndexOutOfRangeException) {
					throw new InvalidOperationException();
				}
			}
		}
	}
#if SL
	static class DataServiceQueryAsyncHelper {
		public static SynchronizationContext SyncContext;
		public static IEnumerable<T> ExecuteAsync<T>(this DataServiceContext context, Uri requestUri) {
			IAsyncResult asyncResult = null;
			SyncContext.Send(new SendOrPostCallback((o) => {
				asyncResult = context.BeginExecute<T>(requestUri, null, null);
			}), null);
			return context.EndExecute<T>(asyncResult);
		}
		public static IEnumerable<T> ExecuteAsync<T>(this DataServiceQuery<T> query){
			IAsyncResult queryAsyncResult = null;
			SyncContext.Send(new SendOrPostCallback((o) => {
				queryAsyncResult = query.BeginExecute(null, null);
			}), null);
			return query.EndExecute(queryAsyncResult);
		}
	}
#endif
}
