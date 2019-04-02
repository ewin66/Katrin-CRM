using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Katrin.AppFramework.Utils;
using System.Collections;

namespace Katrin.AppFramework
{
    [Flags]
    public enum SelectionType
    {
        None = 0,
        FocusedObject = 1,
        MultipleSelection = 2,
        TemporarySelection = 4,
        Full = 3
    };
    public class CustomizeViewShortcutArgs : EventArgs
    {
        private ViewShortcut viewShortcut;
        public CustomizeViewShortcutArgs(ViewShortcut viewShortcut)
        {
            this.viewShortcut = viewShortcut;
        }
        public ViewShortcut ViewShortcut
        {
            get
            {
                return viewShortcut;
            }
        }
    }
    public abstract class View : ISelectionContext, IDisposable
    {
        public const string SecurityReadOnlyItemName = "Security";
        private bool isDisposed = false;
        private string id;
        private string caption;
        private bool isRoot;
        private ErrorMessages errorMessages;
        private object control;
        private BoolList allowEdit = new BoolList(true, BoolListOperatorType.And);
        private BoolList allowNew = new BoolList(true, BoolListOperatorType.And);
        private BoolList allowDelete = new BoolList(true, BoolListOperatorType.And);
        private Point scrollPosition;
        private bool isCreateControlsCalled = false;
        private object tag;
        private Boolean isClosing;
        //protected IModelView model;
        private void allowNew_ResultValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            OnAllowNewChanged();
        }
        private void allowDelete_ResultValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            OnAllowDeleteChanged();
        }
        private void allowEdit_ResultValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            OnAllowEditChanged();
        }
        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }
        protected virtual void OnSelectionTypeChanged()
        {
            if (SelectionTypeChanged != null)
            {
                SelectionTypeChanged(this, EventArgs.Empty);
            }
        }
        protected virtual void OnCurrentObjectChanged()
        {
            if (CurrentObjectChanged != null)
            {
                CurrentObjectChanged(this, EventArgs.Empty);
            }
        }
        protected virtual bool OnQueryCanChangeCurrentObject()
        {
            CancelEventArgs e = new CancelEventArgs();
            if (QueryCanChangeCurrentObject != null)
            {
                QueryCanChangeCurrentObject(this, e);
            }
            return !e.Cancel;
        }
        protected void CheckIsDisposed()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
        protected virtual void OnCaptionChanged()
        {
            if (CaptionChanged != null)
                CaptionChanged(this, EventArgs.Empty);
        }
        protected virtual void OnModelSaving(CancelEventArgs args)
        {
            if (ModelSaving != null)
            {
                ModelSaving(this, args);
            }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnCustomModelSaving(HandledEventArgs args)
        {
            if (CustomModelSaving != null)
            {
                CustomModelSaving(this, args);
            }
        }
        protected virtual void OnModelSaved()
        {
            if (ModelSaved != null)
            {
                ModelSaved(this, EventArgs.Empty);
            }
        }
        protected virtual void OnModelLoaded()
        {
            if (ModelLoaded != null)
            {
                ModelLoaded(this, EventArgs.Empty);
            }
        }
        protected virtual void OnModelChanging()
        {
            if (ModelChanging != null)
            {
                ModelChanging(this, EventArgs.Empty);
            }
        }
        protected virtual void OnModelChanged()
        {
            if (ModelChanged != null)
            {
                ModelChanged(this, EventArgs.Empty);
            }
        }
        protected virtual void OnDisposing(CancelEventArgs args)
        {
            if (Disposing != null)
            {
                Disposing(this, args);
            }
        }
        protected virtual void OnControlsCreating()
        {
            if (ControlsCreating != null)
            {
                ControlsCreating(this, EventArgs.Empty);
            }
        }
        protected virtual void OnControlsCreated()
        {
            if (ControlsCreated != null)
            {
                ControlsCreated(this, EventArgs.Empty);
            }
        }
        protected virtual void OnAllowEditChanged()
        {
            if (AllowEditChanged != null)
            {
                AllowEditChanged(this, EventArgs.Empty);
            }
        }
        protected virtual void OnAllowDeleteChanged()
        {
            if (AllowDeleteChanged != null)
            {
                AllowDeleteChanged(this, EventArgs.Empty);
            }
        }
        protected virtual void OnAllowNewChanged()
        {
            if (AllowNewChanged != null)
            {
                AllowNewChanged(this, EventArgs.Empty);
            }
        }
        protected abstract object CreateControlsCore();
        protected abstract void SaveModelCore();
        protected abstract void LoadModelCore();
        protected abstract void RefreshCore();
        protected virtual void DisposeCore()
        {
        }
        protected virtual void UpdateSecurityModifiers()
        {
        }
        protected virtual ViewShortcut CreateShortcutCore()
        {
            return new ViewShortcut(Id, "");
        }
        protected virtual void CloseCore() { }
        protected void DisposeViewControl()
        {
            if (control is IDisposable)
            {
                ((IDisposable)control).Dispose();
            }
            control = null;
        }
        protected View(bool isRoot)
        {
            allowEdit.ResultValueChanged += new EventHandler<BoolValueChangedEventArgs>(allowEdit_ResultValueChanged);
            allowNew.ResultValueChanged += new EventHandler<BoolValueChangedEventArgs>(allowNew_ResultValueChanged);
            allowDelete.ResultValueChanged += new EventHandler<BoolValueChangedEventArgs>(allowDelete_ResultValueChanged);
            errorMessages = new ErrorMessages();
            this.isRoot = isRoot;
        }
        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }
            SafeExecutor executor = new SafeExecutor(this);
            CancelEventArgs args = new CancelEventArgs();
            executor.Execute(delegate()
            {
                OnDisposing(args);
            });
            if (!args.Cancel)
            {
                isDisposed = true;
                object currentControl = control;
                executor.Execute(delegate()
                {
                    DisposeCore();
                });
                executor.Execute(delegate()
                {
                    BreakLinksToControls();
                });
                errorMessages = null;
                ControlsCreated = null;
                Closing = null;
                Closed = null;
                QueryCanClose = null;
                CaptionChanged = null;
                ModelChanging = null;
                ModelChanged = null;
                ModelSaving = null;
                ModelSaved = null;
                CustomModelSaving = null;
                Disposing = null;
                AllowDeleteChanged = null;
                AllowEditChanged = null;
                AllowNewChanged = null;
                CustomizeViewShortcut = null;
                CurrentObjectChanged = null;
                SelectionChanged = null;
                SelectionTypeChanged = null;
                QueryCanChangeCurrentObject = null;
                if (currentControl != null && currentControl is IDisposable)
                {
                    executor.Dispose((IDisposable)currentControl);
                    currentControl = null;
                }
            }
            executor.ThrowExceptionIfAny();
        }
        public virtual bool IsSameObjectSpace(View view)
        {
            return false;
        }
        public bool Close(bool checkCanClose)
        {
            Boolean result = true;
            if (!isClosing)
            {
                isClosing = true;
                try
                {
                    if (checkCanClose)
                    {
                        result = CanClose();
                    }
                    if (result)
                    {
                        if (Closing != null)
                        {
                            Closing(this, EventArgs.Empty);
                        }
                        CloseCore();
                        if (Closed != null)
                        {
                            Closed(this, EventArgs.Empty);
                        }
                    }
                }
                finally
                {
                    isClosing = false;
                }
            }
            return result;
        }
        public bool Close()
        {
            return Close(true);
        }
        public void CreateControls()
        {
            if (!isCreateControlsCalled)
            {
                CheckIsDisposed();
                isCreateControlsCalled = true;
                OnControlsCreating();
                control = CreateControlsCore();
                OnControlsCreated();
            }
        }
        public ViewShortcut CreateShortcut()
        {
            CheckIsDisposed();
            ViewShortcut viewShortcut = CreateShortcutCore();
            if (CustomizeViewShortcut != null)
            {
                CustomizeViewShortcut(this, new CustomizeViewShortcutArgs(viewShortcut));
            }
            return viewShortcut;
        }
        public void Refresh()
        {
            CheckIsDisposed();
            RefreshCore();
        }
        //public void SetModel(IModelView model)
        //{
        //    CheckIsDisposed();
        //    SaveModel();
        //    OnModelChanging();
        //    this.model = model;
        //    LoadModel();
        //    OnModelChanged();
        //}
        //public void LoadModel()
        //{
        //    CheckIsDisposed();
        //    if (model != null)
        //    {
        //        Caption = model.Caption;
        //        id = model.Id;
        //    }
        //    else
        //    {
        //        Caption = "";
        //        id = "";
        //    }
        //    LoadModelCore();
        //    OnModelLoaded();
        //    if (isCreateControlsCalled)
        //    {
        //        isCreateControlsCalled = false;
        //        CreateControls();
        //    }
        //}
        public void SaveModel()
        {
            CheckIsDisposed();
            CancelEventArgs cancelEventArgs = new CancelEventArgs(false);
            OnModelSaving(cancelEventArgs);
            if (!cancelEventArgs.Cancel)
            {
                HandledEventArgs args = new HandledEventArgs(false);
                OnCustomModelSaving(args);
                if (!args.Handled)
                {
                    SaveModelCore();
                }
                OnModelSaved();
            }
        }
        public bool CanClose()
        {
            if (isRoot)
            {
                CancelEventArgs eventArgs = new CancelEventArgs(false);
                if (QueryCanClose != null)
                {
                    QueryCanClose(this, eventArgs);
                }
                return !eventArgs.Cancel;
            }
            else
            {
                return true;
            }
        }
        public virtual void BreakLinksToControls()
        {
            control = null;
            isCreateControlsCalled = false;
        }
        public override String ToString()
        {
            return GetType().Name + ", ID:" + Id;
        }
        public Boolean CanChangeCurrentObject()
        {
            return OnQueryCanChangeCurrentObject();
        }
        public virtual String GetCurrentObjectCaption()
        {
            return "";
        }
        [Description("Provides access to the object space within which a View was created.")]
        public virtual IObjectSpace ObjectSpace
        {
            get { return null; }
        }
        [Description("Specifies whether a View is root.")]
        public bool IsRoot
        {
            get { return isRoot; }
            set { isRoot = value; }
        }
        [Description("Returns a View's ID.")]
        public string Id
        {
            get { return id; }
            protected set { id = value; }
        }
        [Description("Indicates whether a View's View.Control has been created.")]
        public bool IsControlCreated
        {
            get { return control != null; }
        }
        [Description("Provides access to the current View's error message collection that is populated when Validation Rules get broken.")]
        public ErrorMessages ErrorMessages
        {
            get { return errorMessages; }
        }
        //[Description("This property is obsolete. Use the ObjectView.ObjectTypeInfo property instead.")]
        //public virtual ITypeInfo ObjectTypeInfo
        //{
        //    get { return null; }
        //    set { ;  }
        //}
        [Description("Specifies a View's current object.")]
        public virtual object CurrentObject
        {
            get { return null; }
            set { ; }
        }
        [Description("Specifies a View's selected objects.")]
        public virtual IList SelectedObjects
        {
            get { return null; }
        }
        [Description("Returns the selection type supported by a View.")]
        public virtual SelectionType SelectionType
        {
            get { return SelectionType.None; }
        }
        [Description("Returns the current View's control.")]
        public virtual object Control
        {
            get
            {
                if (!isCreateControlsCalled)
                {
                    throw new InvalidOperationException(
                        "The View.Control property value is not available because the View's control has not been created yet. To access the control, handle the View's ControlsCreated event in a Controller.");
                }
                return control;
            }
        }
        [Description("Specifies the scroll point of Windows in ASP.NET Web applications.")]
        public virtual Point ScrollPosition
        {
            get { return scrollPosition; }
            set { scrollPosition = value; }
        }
        [Description("Specifies a View's caption.")]
        public virtual string Caption
        {
            get { return caption; }
            set
            {
                if (value != caption)
                {
                    caption = value;
                    OnCaptionChanged();
                }
            }
        }
        //[Description("Provides access to information on a View, which is stored in the Application Model. ")]
        //public virtual IModelView Model
        //{
        //    get { return model; }
        //}
        [BindableAttribute(true)]
        [TypeConverterAttribute(typeof(StringConverter))]
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        public BoolList AllowEdit
        {
            get { return allowEdit; }
        }
        public BoolList AllowDelete
        {
            get { return allowDelete; }
        }
        public BoolList AllowNew
        {
            get { return allowNew; }
        }
        public Boolean IsDisposed
        {
            get { return isDisposed; }
        }
        String ISelectionContext.Name
        {
            get { return Caption; }
        }
        public event EventHandler ControlsCreating;
        public event EventHandler ControlsCreated;
        public event EventHandler<CancelEventArgs> QueryCanClose;
        public event EventHandler Closing;
        public event EventHandler Closed;
        public event EventHandler CaptionChanged;
        public event EventHandler CurrentObjectChanged;
        public event EventHandler SelectionChanged;
        public event EventHandler SelectionTypeChanged;
        public event EventHandler<CancelEventArgs> QueryCanChangeCurrentObject;
        public event EventHandler AllowEditChanged;
        public event EventHandler AllowDeleteChanged;
        public event EventHandler AllowNewChanged;
        public event EventHandler ModelChanging;
        public event EventHandler ModelChanged;
        public event EventHandler<CancelEventArgs> ModelSaving;
        public event EventHandler ModelSaved;
        public event EventHandler ModelLoaded;
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<HandledEventArgs> CustomModelSaving;
        public event CancelEventHandler Disposing;
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<CustomizeViewShortcutArgs> CustomizeViewShortcut;
    }
}
