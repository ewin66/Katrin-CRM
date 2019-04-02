using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.Common.Core
{

    public class View : DevExpress.XtraEditors.XtraUserControl, IView
    {
        private IActionContext _context;
        private bool _isLocked;

        public event EventHandler<ContextChangingEventArgs> ContextChanging;
        public event EventHandler ContextChanged;
        public event EventHandler CurrentChanged;

        public string FilterString { get; set; }

        public IActionContext Context
        {
            get
            {
                if (_context == null) 
                { 
                    Context = new ActionContext();
                }
                return _context;
            }
            set
            {
                if (_context != value)
                {
                    if (_context != null)
                    {
                        _context.CurrentChanged -= ContextCurrentChanged;
                        _context.GetDataSource -= OnGetDataSource;
                        _context.DataSourceChange -= OnDataSourceChange;
                    }
                    OnContextChanging(new ContextChangingEventArgs(_context, value));
                    _context = value;
                    if (_context != null)
                    {
                        _context.CurrentChanged += ContextCurrentChanged;
                        _context.GetDataSource += OnGetDataSource;
                        _context.DataSourceChange += OnDataSourceChange;
                    }
                    OnContextChanged(new EventArgs());
                }
            }
        }

        void ContextCurrentChanged(object sender, EventArgs e)
        {
            OnCurrentChanged(e);
            
        }

        protected virtual void OnContextChanging(ContextChangingEventArgs e)
        {
            var handler = ContextChanging;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnContextChanged(EventArgs e)
        {
            var handler = ContextChanged;
            if (handler != null) handler(this, e);
        }

        public virtual void OnCurrentChanged(EventArgs e)
        {
            if (_isLocked) return;
            var handler = CurrentChanged;
            if (handler != null) handler(this, e);
        }

        protected virtual void BindData()
        {
        }

        private void OnGetDataSource(object sender, EventArgs e)
        {
            if (_isLocked) return;
            BindData();
        }

        protected virtual void OnDataSourceChange(object sender, EventArgs e)
        {
        }

        public void Lock()
        {
            _isLocked = true;
        }

        public void Unlock()
        {
            _isLocked = false;
        }
    }

    public interface IView
    {
        event EventHandler<ContextChangingEventArgs> ContextChanging;
        event EventHandler ContextChanged;
        event EventHandler CurrentChanged;
        IActionContext Context { get; set; }
        void Lock();
        void Unlock();
    }

    public class ContextChangingEventArgs : EventArgs
    {
        public ContextChangingEventArgs(IActionContext originalValue, IActionContext newValue)
        {
            Original = originalValue;
            New = newValue;
        }

        public IActionContext Original { get; private set; }
        public IActionContext New { get; private set; }
    }

    public class Controller
    {
        public virtual View CreateView()
        {
            return new View();
        }

        public void ShowView()
        {
        }

        public void CloseView()
        {
        }
    }
}
