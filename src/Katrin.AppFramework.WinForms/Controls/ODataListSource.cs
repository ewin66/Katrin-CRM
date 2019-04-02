using Katrin.AppFramework.WinForms.Grid;
using DevExpress.Data.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Katrin.AppFramework.WinForms.Controls
{
    public class ODataListSource : BindingSource
    {
        private SynchronizationContext _context;
        private string _objectName;
        private CriteriaOperator _filter;
      

        public CriteriaOperator QueryFilter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        private List<string> _addtionProperties;
        public ODataListSource()
        {

        }
        public ODataListSource(string objectName, CriteriaOperator filter, List<string> addtionProperties)
        {
            _filter = filter;
            _context = SynchronizationContext.Current;
            _objectName = objectName;
            _addtionProperties = addtionProperties;
        }       
     
        public void AsyncRefreshDataSource()
        {
            Func<System.Collections.IList> queryDelegate = QueryData;
            queryDelegate.BeginInvoke(new AsyncCallback(OnQueryCompleted), queryDelegate);
        }

        public void RefreshDataSource()
        {
           
            DataSource = QueryData();
        }

        private void OnQueryCompleted(IAsyncResult ar)
        {
            var queryDelegate = (Func<System.Collections.IList>)ar.AsyncState;

            System.Collections.IList result = queryDelegate.EndInvoke(ar);
            Action<object> action = new Action<object>(list =>
            {
                DataSource = null;
                DataSource = list;
            });
            _context.Post(new SendOrPostCallback(action), result);
        }

        

        private System.Collections.IList QueryData()
        {
            IObjectSpace objectSpace = new ODataObjectSpace();
            var projections = GridViewExtension.GetColumnProjections(_objectName, _addtionProperties);
            var propertyDictionary = projections.ToDictionary(cp => cp.Projection, cp => cp.QueryExpression);
            var fetchColumns = propertyDictionary.Select(kvp => string.Format("{0} AS {1}", kvp.Value, kvp.Key)).ToArray();
            var selector = string.Format("new({0})", string.Join(",", fetchColumns));
            var list = objectSpace.GetObjectQuery(_objectName, selector, _filter).ToList();
            return list;
        }
        protected override void Dispose(bool disposing)
        {
            this.Clear();
            if (this.DataSource != null)
            {
                this.DataSource = null;
            }
            base.Dispose(disposing);
        }
    }
}
