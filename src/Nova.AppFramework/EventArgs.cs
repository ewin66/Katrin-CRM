
using System;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;

namespace Katrin.AppFramework
{
    public enum ConfirmationResult { Yes, No, Cancel };
    public enum ConfirmationType { NeedSaveChanges, CancelChanges };
	public class CustomProcessShortcutEventArgs : HandledEventArgs {
		private View view;
		public CustomProcessShortcutEventArgs(ViewShortcut shortcut) {
			this.Shortcut = shortcut;
		}
		public ViewShortcut Shortcut;
		public View View {
			get { return view; }
			set { view = value; }
		}
	}
	public class ShortcutProcessedEventArgs : EventArgs {
		private View view;
		private ViewShortcut shortcut;
		public ShortcutProcessedEventArgs(ViewShortcut shortcut, View view) {
			this.shortcut = shortcut;
			this.view = view;
		}
		public ViewShortcut Shortcut {
			get { return shortcut; }
		}
		public View View {
			get { return view; }
		}
	}
	public class HandleShortcutProcessingExceptionEventArgs : HandledEventArgs {
		private ViewShortcut shortcut;
		private Exception shortcutProcessingException;
		public HandleShortcutProcessingExceptionEventArgs(ViewShortcut shortcut, Exception shortcutProcessingException) {
			this.Handled = false;
			this.shortcut = shortcut;
			this.shortcutProcessingException = shortcutProcessingException;
		}
		public ViewShortcut Shortcut {
			get { return shortcut; }
		}
		public Exception ShortcutProcessingException {
			get { return shortcutProcessingException; }
		}
	}
	public class ViewCreatingEventArgs : EventArgs {
		private string viewID;
		private IObjectSpace objectSpace;
		private bool isRoot;
		private View view;
		public ViewCreatingEventArgs(string viewID, IObjectSpace objectSpace, bool isRoot) {
			this.viewID = viewID;
			this.objectSpace = objectSpace;
			this.isRoot = isRoot;
		}
		public string ViewID {
			get { return viewID; }
			set { viewID = value; }
		}
		public IObjectSpace ObjectSpace {
			get { return objectSpace; }
		}
		public bool IsRoot {
			get { return isRoot; }
		}
		public View View {
			get { return view; }
			set { view = value; }
		}
	}
    //public class ListViewCreatingEventArgs : ViewCreatingEventArgs {
    //    private CollectionSourceBase collectionSource;
    //    public ListViewCreatingEventArgs(string viewID, CollectionSourceBase collectionSource, bool isRoot)
    //        : base(viewID, collectionSource.ObjectSpace, isRoot) {
    //        this.collectionSource = collectionSource;
    //    }
    //    public CollectionSourceBase CollectionSource {
    //        get { return collectionSource; }
    //    }
    //    public new ListView View {
    //        get { return (ListView)base.View; }
    //        set { base.View = value; }
    //    }
    //}
	public class ViewCreatedEventArgs : EventArgs {
		private View view;
		public ViewCreatedEventArgs(View view) {
			this.view = view;
		}
		public View View {
			get { return view; }
			set { view = value; } 
		}
	}
    //public class ListViewCreatedEventArgs : ViewCreatedEventArgs {
    //    public ListViewCreatedEventArgs(ListView listView) : base(listView) { }
    //    public ListView ListView {
    //        get { return (ListView)base.View; }
    //        set { base.View = value; } 
    //    }
    //}
    //public class DetailViewCreatingEventArgs : ViewCreatingEventArgs {
    //    private Object obj;
    //    public DetailViewCreatingEventArgs(string viewID, IObjectSpace objectSpace, Object obj, bool isRoot)
    //        : base(viewID, objectSpace, isRoot) {
    //        this.obj = obj;
    //    }
    //    public Object Obj {
    //        get { return obj; }
    //    }
    //    public new DetailView View {
    //        get { return (DetailView)base.View; }
    //        set { base.View = value; }
    //    }
    //}
    //public class DetailViewCreatedEventArgs : ViewCreatedEventArgs {
    //    public DetailViewCreatedEventArgs(DetailView view) : base(view) { }
    //    public new DetailView View {
    //        get { return (DetailView)base.View; }
    //        set { base.View = value; }
    //    }
    //}
    //public class DashboardViewCreatingEventArgs : ViewCreatingEventArgs {
    //    public DashboardViewCreatingEventArgs(String viewId, IObjectSpace objectSpace) : base(viewId, objectSpace, true) { }
    //    public new DashboardView View {
    //        get { return (DashboardView)base.View; }
    //        set { base.View = value; }
    //    }
    //}
    //public class DashboardViewCreatedEventArgs : ViewCreatedEventArgs {
    //    public DashboardViewCreatedEventArgs(DashboardView view) : base(view) { }
    //    public new DashboardView View {
    //        get { return (DashboardView)base.View; }
    //    }
    //}
    //public class ViewShowingEventArgs : EventArgs {
    //    private Frame sourceFrame;
    //    private Frame targetFrame;
    //    private View view;
    //    public ViewShowingEventArgs(Frame targetFrame, View view, Frame sourceFrame) {
    //        this.targetFrame = targetFrame;
    //        this.sourceFrame = sourceFrame;
    //        this.view = view;
    //    }
    //    public Frame SourceFrame {
    //        get { return sourceFrame; }
    //    }
    //    public Frame TargetFrame {
    //        get { return targetFrame; }
    //    }
    //    public View View {
    //        get { return view; }
    //    }
    //}
    //public class ViewShownEventArgs : EventArgs {
    //    private Frame sourceFrame;
    //    private Frame targetFrame;
    //    public ViewShownEventArgs(Frame targetFrame, Frame sourceFrame) {
    //        this.targetFrame = targetFrame;
    //        this.sourceFrame = sourceFrame;
    //    }
    //    public Frame TargetFrame {
    //        get { return targetFrame; }
    //    }
    //    public Frame SourceFrame {
    //        get { return sourceFrame; }
    //    }
    //    [Obsolete("Use the 'TargetFrame' property instead."), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
    //    public Frame Frame {
    //        get { return targetFrame; }
    //    }
    //}
    //public class CustomizeTemplateEventArgs : EventArgs {
    //    private TemplateContext context;
    //    private IFrameTemplate template;
    //    public CustomizeTemplateEventArgs(IFrameTemplate template, TemplateContext context) {
    //        this.template = template;
    //        this.context = context;
    //    }
    //    public IFrameTemplate Template {
    //        get { return template; }
    //    }
    //    public TemplateContext Context {
    //        get { return context; }
    //    }
    //}
    //public class CreateCustomTemplateEventArgs : EventArgs {
    //    private IFrameTemplate template;
    //    private TemplateContext context;
    //    private XafApplication application;
    //    public CreateCustomTemplateEventArgs(XafApplication application, TemplateContext context) {
    //        this.context = context;
    //        this.application = application;
    //    }
    //    public IFrameTemplate Template {
    //        get { return template; }
    //        set { template = value; }
    //    }
    //    public TemplateContext Context {
    //        get { return context; }
    //    }
    //    public XafApplication Application {
    //        get { return application; }
    //    }
    //}
    //public class CustomCheckCompatibilityEventArgs : HandledEventArgs {
    //    private IObjectSpaceProvider objectSpaceProvider;
    //    private IList<ModuleBase> modules;
    //    private string applicationName;
    //    private bool isCompatibilityChecked;
    //    public CustomCheckCompatibilityEventArgs(bool isCompatibilityChecked, IObjectSpaceProvider objectSpaceProvider, IList<ModuleBase> modules, string applicationName) {
    //        this.isCompatibilityChecked = isCompatibilityChecked;
    //        this.objectSpaceProvider = objectSpaceProvider;
    //        this.modules = modules;
    //        this.applicationName = applicationName;
    //    }
    //    public IObjectSpaceProvider ObjectSpaceProvider {
    //        get { return objectSpaceProvider; }
    //    }
    //    public IList<ModuleBase> Modules {
    //        get { return modules; }
    //    }
    //    public string ApplicationName {
    //        get { return applicationName; }
    //    }
    //    public bool IsCompatibilityChecked {
    //        get { return isCompatibilityChecked; }
    //    }
    //}
    //public class DatabaseVersionMismatchEventArgs : HandledEventArgs {
    //    private DatabaseUpdater updater;
    //    private CompatibilityError compatibilityError;
    //    public DatabaseVersionMismatchEventArgs(DatabaseUpdater updater, CompatibilityError compatibilityError) {
    //        this.updater = updater;
    //        this.compatibilityError = compatibilityError;
    //    }
    //    public DatabaseUpdater Updater {
    //        get { return updater; }
    //        set { updater = value; }
    //    }
    //    public CompatibilityError CompatibilityError {
    //        get { return compatibilityError; }
    //        set { compatibilityError = value; }
    //    }
    //}
    //public class LastLogonParametersReadingEventArgs : HandledEventArgs {
    //    private object logonObject;
    //    private SettingsStorage settingsStorage;
    //    public LastLogonParametersReadingEventArgs(object logonObject, SettingsStorage settingsStorage)
    //        : base() {
    //        this.logonObject = logonObject;
    //        this.settingsStorage = settingsStorage;
    //    }
    //    public object LogonObject {
    //        get { return logonObject; }
    //    }
    //    public SettingsStorage SettingsStorage {
    //        get { return settingsStorage; }
    //    }
    //}
    //public class LastLogonParametersReadEventArgs : EventArgs {
    //    private object logonObject;
    //    private SettingsStorage settingsStorage;
    //    public LastLogonParametersReadEventArgs(object logonObject, SettingsStorage settingsStorage)
    //        : base() {
    //        this.logonObject = logonObject;
    //        this.settingsStorage = settingsStorage;
    //    }
    //    public object LogonObject {
    //        get { return logonObject; }
    //    }
    //    public SettingsStorage SettingsStorage {
    //        get { return settingsStorage; }
    //    }
    //}
    //public class LastLogonParametersWritingEventArgs : HandledEventArgs {
    //    private DetailView detailView;
    //    private object logonObject;
    //    private SettingsStorage settingsStorage;
    //    public LastLogonParametersWritingEventArgs(DetailView detailView, object logonObject, SettingsStorage settingsStorage)
    //        : base() {
    //        this.detailView = detailView;
    //        this.logonObject = logonObject;
    //        this.settingsStorage = settingsStorage;
    //    }
    //    public DetailView DetailView {
    //        get { return detailView; }
    //    }
    //    public object LogonObject {
    //        get { return logonObject; }
    //    }
    //    public SettingsStorage SettingsStorage {
    //        get { return settingsStorage; }
    //    }
    //}
    //public class CreateCustomCollectionSourceEventArgs : EventArgs {
    //    private IObjectSpace objectSpace;
    //    private Type objectType;
    //    private string listViewID;
    //    private CollectionSourceMode mode;
    //    private CollectionSourceBase collectionSource;
    //    public CreateCustomCollectionSourceEventArgs(IObjectSpace objectSpace, Type objectType, String listViewID, CollectionSourceMode mode) {
    //        this.objectSpace = objectSpace;
    //        this.objectType = objectType;
    //        this.listViewID = listViewID;
    //        this.mode = mode;
    //    }
    //    public IObjectSpace ObjectSpace {
    //        get { return objectSpace; }
    //    }
    //    public Type ObjectType {
    //        get { return objectType; }
    //    }
    //    public string ListViewID {
    //        get { return listViewID; }
    //    }
    //    public CollectionSourceMode Mode {
    //        get { return mode; }
    //    }
    //    public CollectionSourceBase CollectionSource {
    //        get { return collectionSource; }
    //        set { collectionSource = value; }
    //    }
    //}
    //public class CreateCustomPropertyCollectionSourceEventArgs : EventArgs {
    //    private IObjectSpace objectSpace;
    //    private Object masterObject;
    //    private IMemberInfo memberInfo;
    //    private String listViewID;
    //    private Type masterObjectType;
    //    private CollectionSourceMode mode;
    //    private PropertyCollectionSource propertyCollectionSource;
    //    public CreateCustomPropertyCollectionSourceEventArgs(IObjectSpace objectSpace, Type masterObjectType, Object masterObject, IMemberInfo memberInfo, String listViewID, CollectionSourceMode mode) {
    //        this.objectSpace = objectSpace;
    //        this.masterObject = masterObject;
    //        this.memberInfo = memberInfo;
    //        this.listViewID = listViewID;
    //        this.masterObjectType = masterObjectType;
    //        this.mode = mode;
    //    }
    //    public Type MasterObjectType {
    //        get { return masterObjectType; }
    //    }
    //    public IObjectSpace ObjectSpace {
    //        get { return objectSpace; }
    //    }
    //    public object MasterObject {
    //        get { return masterObject; }
    //    }
    //    public IMemberInfo MemberInfo {
    //        get { return memberInfo; }
    //    }
    //    public string ListViewID {
    //        get { return listViewID; }
    //    }
    //    public CollectionSourceMode Mode {
    //        get { return mode; }
    //    }
    //    public PropertyCollectionSource PropertyCollectionSource {
    //        get { return propertyCollectionSource; }
    //        set { propertyCollectionSource = value; }
    //    }
    //}
    //public class CreateCustomLogonParameterStoreEventArgs : HandledEventArgs {
    //    private SettingsStorage settingsStorage;
    //    public SettingsStorage Storage {
    //        get { return settingsStorage; }
    //        set { settingsStorage = value; }
    //    }
    //}
    //public class CreateCustomLogonWindowControllersEventArgs : EventArgs {
    //    private List<Controller> controllers = new List<Controller>();
    //    public List<Controller> Controllers {
    //        get { return controllers; }
    //        set { controllers = value; }
    //    }
    //}
	public class CreateCustomLogonWindowObjectSpaceEventArgs : EventArgs {
		private IObjectSpace objectSpace;
		private object logonParameters;
		public CreateCustomLogonWindowObjectSpaceEventArgs(object logonParameters) {
			this.logonParameters = logonParameters;
		}
		public IObjectSpace ObjectSpace {
			get { return objectSpace; }
			set { objectSpace = value; }
		}
		public object LogonParameters {
			get { return logonParameters; }
		}
	}
	public class LogonEventArgs : EventArgs {
		private object logonParameters;
		public LogonEventArgs(object logonParameters)
			: base() {
			this.logonParameters = logonParameters;
		}
		public object LogonParameters {
			get { return logonParameters; }
		}
	}
	public class LoggingOffEventArgs : CancelEventArgs {
		private object logonParameters;
		private bool canCancel;
		public LoggingOffEventArgs(object logonParameters, bool canCancel)
			: base() {
			this.logonParameters = logonParameters;
			this.canCancel = canCancel;
		}
		public object LogonParameters {
			get { return logonParameters; }
		}
		public bool CanCancel {
			get { return canCancel; }
		}
	}
    //public class SetupEventArgs : EventArgs {
    //    private ExpressApplicationSetupParameters setupParameters;
    //    public SetupEventArgs(ExpressApplicationSetupParameters setupParameters)
    //        : base() {
    //        this.setupParameters = setupParameters;
    //    }
    //    public ExpressApplicationSetupParameters SetupParameters {
    //        get { return setupParameters; }
    //    }
    //}
	public class LogonFailedEventArgs : HandledEventArgs {
		private object logonParameters;
		private Exception exception;
		public LogonFailedEventArgs(object logonParameters, Exception exception)
			: base() {
			this.logonParameters = logonParameters;
			this.exception = exception;
		}
		public object LogonParameters {
			get { return logonParameters; }
		}
		public Exception Exception {
			get { return exception; }
		}
	}
	public class ObjectSpaceCreatedEventArgs : EventArgs {
		private IObjectSpace objectSpace;
		public IObjectSpace ObjectSpace {
			get { return objectSpace; }
		}
		public ObjectSpaceCreatedEventArgs(IObjectSpace objectSpace)
			: base() {
			this.objectSpace = objectSpace;
		}
	}
    //public class CreateCustomModelDifferenceStoreEventArgs : HandledEventArgs {
    //    private ModelDifferenceStore store;
    //    internal List<KeyValuePair<string, ModelStoreBase>> ExtraDiffStores = new List<KeyValuePair<string, ModelStoreBase>>();
    //    public ModelDifferenceStore Store {
    //        get { return store; }
    //        set { store = value; }
    //    }
    //    public void AddExtraDiffStore(string id, ModelStoreBase store) {
    //        ExtraDiffStores.Add(new KeyValuePair<string, ModelStoreBase>(id, store));
    //    }
    //}
	public class CustomizeLanguageEventArgs : EventArgs {
		private string languageName;
		private string userLanguageName;
		private string preferredLanguageName;
		public CustomizeLanguageEventArgs(string languageName, string userLanguageName, string preferredLanguageName) {
			this.languageName = languageName;
			this.userLanguageName = userLanguageName;
			this.preferredLanguageName = preferredLanguageName;
		}
		public string LanguageName {
			get { return languageName; }
			set { languageName = value; }
		}
		public string UserLanguageName {
			get { return userLanguageName; }
		}
		public string PreferredLanguageName {
			get { return preferredLanguageName; }
		}
	}
	public class CustomizeFormattingCultureEventArgs : EventArgs {
		private CultureInfo formattingCulture;
		private string userLanguageName;
		private string preferredLanguageName;
		public CustomizeFormattingCultureEventArgs(CultureInfo formattingCulture, string userLanguageName, string preferredLanguageName) {
			this.formattingCulture = formattingCulture;
			this.userLanguageName = userLanguageName;
			this.preferredLanguageName = preferredLanguageName;
		}
		public CultureInfo FormattingCulture {
			get { return formattingCulture; }
			set { formattingCulture = value; }
		}
		public string UserLanguageName {
			get { return userLanguageName; }
		}
		public string PreferredLanguageName {
			get { return preferredLanguageName; }
		}
	}
    //public class CreateCustomObjectSpaceProviderEventArgs : EventArgs {
    //    private string connectionString;
    //    private IDbConnection connection;
    //    private IObjectSpaceProvider objectSpaceProvider;
    //    public CreateCustomObjectSpaceProviderEventArgs(IDbConnection connection) {
    //        this.connection = connection;
    //    }
    //    public CreateCustomObjectSpaceProviderEventArgs(string connectionString) {
    //        this.connectionString = connectionString;
    //    }
    //    public IDbConnection Connection {
    //        get { return connection; }
    //    }
    //    public string ConnectionString {
    //        get { return connectionString; }
    //    }
    //    public IObjectSpaceProvider ObjectSpaceProvider {
    //        get { return objectSpaceProvider; }
    //        set { objectSpaceProvider = value; }
    //    }
    //}
	public class ObjectManipulatingEventArgs : EventArgs {
		private Object obj;
		public ObjectManipulatingEventArgs(Object obj) {
			this.obj = obj;
		}
		public Object Object {
			get { return obj; }
		}
	}
	public class ObjectsManipulatingEventArgs : EventArgs {
		private ICollection objects;
		public ObjectsManipulatingEventArgs(object theObject) {
			this.objects = new object[] { theObject };
		}
		public ObjectsManipulatingEventArgs(ICollection objects) {
			this.objects = objects;
		}
		public ICollection Objects {
			get { return objects; }
		}
	}
	public class DeletingEventArgs : EventArgs {
		private IList objects;
		public DeletingEventArgs(IList objects) {
			this.objects = objects;
		}
		public IList Objects {
			get { return objects; }
		}
	}
	public class ObjectChangedEventArgs : ObjectManipulatingEventArgs {
		private System.Reflection.MemberInfo memberInfo;
		private String propertyName;
		private Object newValue;
		private Object oldValue;
		public ObjectChangedEventArgs(Object obj, String propertyName, Object oldValue, Object newValue)
			: base(obj) {
			this.propertyName = propertyName;
			this.newValue = newValue;
			this.oldValue = oldValue;
		}
        public ObjectChangedEventArgs(Object obj, System.Reflection.MemberInfo memberInfo, Object oldValue, Object newValue)
			: base(obj) {
			this.newValue = newValue;
			this.oldValue = oldValue;
			this.memberInfo = memberInfo;
		}
		public String PropertyName {
			get {
				if(memberInfo != null) {
					return memberInfo.Name;
				}
				else {
					return propertyName;
				}
			}
		}
        public System.Reflection.MemberInfo MemberInfo
        {
			get { return memberInfo; }
		}
		public Object OldValue {
			get { return oldValue; }
		}
		public Object NewValue {
			get { return newValue; }
		}
	}
	public class ValueStoringEventArgs : EventArgs {
		private Object oldValue;
		private Object newValue;
		public ValueStoringEventArgs(Object oldValue, Object newValue)
			: base() {
			this.oldValue = oldValue;
			this.newValue = newValue;
		}
		public Object OldValue {
			get { return oldValue; }
		}
		public Object NewValue {
			get { return newValue; }
		}
	}
	public class ValidateObjectEventArgs : ObjectManipulatingEventArgs {
		private Boolean valid;
		private String errorText = "";
		public ValidateObjectEventArgs(Object obj, Boolean valid)
			: base(obj) {
			this.valid = valid;
		}
		public Boolean Valid {
			get { return valid; }
			set { valid = value; }
		}
		public String ErrorText {
			get { return errorText; }
			set { errorText = value; }
		}
	}
	public class ConfirmationEventArgs : EventArgs {
		private ConfirmationType confirmationType;
		private ConfirmationResult confirmationResult;
		public ConfirmationEventArgs(ConfirmationType confirmationType, ConfirmationResult confirmationResult)
			: base() {
			this.confirmationType = confirmationType;
			this.confirmationResult = confirmationResult;
		}
		public ConfirmationType ConfirmationType {
			get { return confirmationType; }
		}
		public ConfirmationResult ConfirmationResult {
			get { return confirmationResult; }
			set { confirmationResult = value; }
		}
	}
	public class CompletedEventArgs : HandledEventArgs {
		private bool isCompleted = true;
		public bool IsCompleted {
			get { return isCompleted; }
			set { isCompleted = value; }
		}
	}
	public class CustomDeleteObjectsEventArgs : HandledEventArgs {
		private ICollection objects;
		public CustomDeleteObjectsEventArgs(ICollection objects) {
			this.objects = objects;
		}
		public ICollection Objects {
			get { return objects; }
		}
	}
    //public class ModuleRegisteredEventArgs : EventArgs {
    //    private ModuleBase module;
    //    public ModuleRegisteredEventArgs(ModuleBase module) {
    //        this.module = module;
    //    }
    //    public ModuleBase Module {
    //        get { return module; }
    //    }
    //}
    //public class CustomizeTypesInfoEventArgs : EventArgs {
    //    private ITypesInfo typesInfo;
    //    public CustomizeTypesInfoEventArgs(ITypesInfo typesInfo) {
    //        this.typesInfo = typesInfo;
    //    }
    //    public ITypesInfo TypesInfo {
    //        get { return typesInfo; }
    //    }
    //}
	public class RemovingTypeWithDependenciesEventArgs : EventArgs {
		private Type type;
		private ICollection<Type> dependentTypes;
		private ICollection<Type> requiredTypes;
		public RemovingTypeWithDependenciesEventArgs(Type type, ICollection<Type> dependentTypes, ICollection<Type> requiredTypes) {
			this.type = type;
			this.dependentTypes = dependentTypes;
			this.requiredTypes = requiredTypes;
		}
		public Type Type {
			get {
				return type;
			}
		}
		public ICollection<Type> DependentTypes {
			get {
				return dependentTypes;
			}
		}
		public ICollection<Type> RequiredTypes {
			get {
				return requiredTypes;
			}
		}
	}
	public class UsingTypeEventArgs : EventArgs {
		private Type type;
		public UsingTypeEventArgs(Type type) {
			this.type = type;
		}
		public Type Type {
			get {
				return type;
			}
		}
	}
	public class UsingAssemblyEventArgs : EventArgs {
		private Assembly assembly;
		public UsingAssemblyEventArgs(Assembly assembly) {
			this.assembly = assembly;
		}
		public Assembly Assembly {
			get {
				return assembly;
			}
		}
	}
	public delegate void UsingTypeEventHandler(object sender, UsingTypeEventArgs e);
	public delegate bool RemovingTypeWithDependenciesEventHandler(object sender, RemovingTypeWithDependenciesEventArgs e);
	public delegate void UsingAssemblyEventHandler(object sender, UsingAssemblyEventArgs e);
    //public class ViewChangingEventArgs : EventArgs {
    //    private Frame sourceFrame;
    //    private View view;
    //    private bool disposeOldView;
    //    public ViewChangingEventArgs(View view, Frame sourceFrame, bool disposeOldView) {
    //        this.sourceFrame = sourceFrame;
    //        this.view = view;
    //        this.disposeOldView = disposeOldView;
    //    }
    //    public Frame SourceFrame {
    //        get { return sourceFrame; }
    //    }
    //    public View View {
    //        get { return view; }
    //    }
    //    public bool DisposeOldView {
    //        get { return disposeOldView; }
    //        set { disposeOldView = value; }
    //    }
    //}
    //public class ViewChangedEventArgs : EventArgs {
    //    private Frame sourceFrame;
    //    public ViewChangedEventArgs(Frame sourceFrame) {
    //        this.sourceFrame = sourceFrame;
    //    }
    //    public Frame SourceFrame {
    //        get { return sourceFrame; }
    //    }
    //}
    //public class ProcessActionContainerEventArgs : EventArgs {
    //    private IActionContainer actionContainer;
    //    public ProcessActionContainerEventArgs(IActionContainer actionContainer) {
    //        this.actionContainer = actionContainer;
    //    }
    //    public IActionContainer ActionContainer {
    //        get { return actionContainer; }
    //    }
    //}
    //public class DatabaseUpdaterEventArgs : EventArgs {
    //    public DatabaseUpdaterEventArgs(DatabaseUpdater updater) {
    //        Updater = updater;
    //    }
    //    public DatabaseUpdater Updater { get; set; }
    //}
}
