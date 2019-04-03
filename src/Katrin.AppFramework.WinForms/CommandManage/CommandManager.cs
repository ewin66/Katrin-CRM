using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.WinForms.ContextMenu;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.XtraBars;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.CommandManage
{
    /// <summary>
    /// UICommand Manager.
    /// date:2012-11-16
    /// </summary>
    class CommandManager : ICommandRegister, IBarItemFinder,IDisposable,IRunTimeCommandRigister
    {
        private Dictionary<string, IUICommand> _commands;
        //<id,groupName>
        private Dictionary<string,Codon> _dynamicGroups;
        private IWorkSpaceContext _caller;
        private BarManager _barManager;
        private IControllerFinder _controllerFinder;
        public CommandManager(IWorkSpaceContext caller, BarManager manager)
        {
            this._commands = new Dictionary<string, IUICommand>();
            this._caller = caller;
            this._barManager = manager;
            this._dynamicGroups = new Dictionary<string, Codon>();
            this._controllerFinder = caller.ControllerFinder;
            
        }

        #region PrivateMember
        private void AddRibbonCommand(string commandId,
            string ribbonPath,
            string checkForViewId)
        {
            IUICommand cmdExist = this.FindCommand(ribbonPath);
            if (cmdExist != null)
            {
                throw  new Exception("Command Exist:" + ribbonPath);
            }
            UICommand cmd = new UICommand(commandId, ribbonPath, CommandSources.Ribbon, checkForViewId);
            this._commands.Add(commandId, cmd);
        }

        private void AddCustomCommand(string commandId,        
           string checkForViewId,
            BarItem item,
            ICommand action,
            IEnumerable<ICondition> conditions,
            string controllerId)
        {
            UICommand cmd = new UICommand(commandId,
                CommandSources.Custom, 
                checkForViewId,
                item,
                action,
                conditions,
                this._controllerFinder);
            cmd.controllerId = controllerId;
            this._commands.Add(commandId, cmd);
        }

        private void AddDynamicContainer(string commandId,
            BarSubItem item,
            ICommand action,
            IEnumerable<ICondition> conditions,
            string groupName)
        {
            UICommand cmd = new UICommand(commandId,
                CommandSources.RibbonDynamicGroup,
                item, action,
                conditions,
                groupName,
                this,
                this._controllerFinder);
            this._commands.Add(commandId, cmd);
        }

        private void LoadCommand(Codon codon,MenuItemDescriptor descriptor)
        {
            if (!codon.Properties.Contains("source"))
            {
                throw new Exception(string.Format("source not found in command config:id ={0},name={1}", codon.Id, codon.Name));
            }

            string source = codon.Properties["source"];
            if (source == "Ribbon")
            {
                this.LoadRibbonCommand(codon);
            }
            else if (source == "Custom")
            {
                this.LoadCustomCommand(codon,descriptor);
            }
            else if (source == "RibbonDynamicGroup")
            {
                this.LoadDynamicGroup(codon);
            }
            else
            {
                throw new Exception(string.Format("Unknown commmandType:{0},id ={1},name={2}", source, codon.Id, codon.Name));
            }

        }

        private void LoadRibbonCommand(Codon codon)
        {
            string commandId = codon.Id;
            string checkForViewId = string.Empty;
            string cmdPath = string.Empty;

            if(!codon.Properties.Contains("cmdPath"))
            {
                 throw new Exception(string.Format("cmdPath not found:id ={0},name={1}", codon.Id, codon.Name));
            }
            if (codon.Properties.Contains("checkForViewId"))
            {
                checkForViewId = codon.Properties["checkForViewId"];
            }
            cmdPath = codon.Properties["cmdPath"];          
            this.AddRibbonCommand(commandId, cmdPath, checkForViewId);
        }

        private void LoadCustomCommand(Codon codon,MenuItemDescriptor descriptor)
        {
            string commandId = codon.Id;
            string builderid = string.Empty;
            string checkForViewId = string.Empty;
            string controllerId = string.Empty;

            //builder
            if (string.IsNullOrEmpty(codon.Properties["builderid"]))
            {
               
                throw new Exception(string.Format("BuiderID not found:codonid ={0},condonname = {1}", codon.Id, codon.Name));
            }
            else
            {
                builderid = codon.Properties["builderid"];
            }

            if (!string.IsNullOrEmpty(codon.Properties["controllerId"]))
            {
                controllerId = codon.Properties["controllerId"];
            }
            //checkForViewId
            if (!string.IsNullOrEmpty(codon.Properties["checkForViewId"]))
            {
                checkForViewId = codon.Properties["checkForViewId"];
            }
            

            //build item
            IPartBuilder buider = RibbonBuilderManager.GetBuider(builderid);
            object item = buider.Build(codon, this._controllerFinder.FindController(string.Empty), codon.Conditions);

            if (!(item is BarItem))
            {
                throw new Exception(string.Format("Builded Custom Command object is not BarItem:id ={0},name = {1}", codon.Id, codon.Name));
            }
            if (string.IsNullOrEmpty(codon.Properties["class"]))
            {
                throw new Exception(string.Format("Action Command Class not defined in Custom Command:id ={0},name = {1}", codon.Id, codon.Name));
            }
            //build action command
            ICommand command = (ICommand)codon.AddIn.CreateObject(codon.Properties["class"]);
                  
            BarItem barItem = item as BarItem;
            CommandDrawer drawer = new CommandDrawer();
            drawer.SetItemGlyph(codon, barItem);
            this._barManager.Items.Add(barItem);
            this.AddCustomCommand(commandId, checkForViewId, barItem, command,descriptor.Conditions,controllerId);
        }

        private void LoadDynamicGroup(Codon codon)
        {
            string commandId = codon.Id;
            string groupName = string.Empty;
            ICommand command = null;
            string labelConfig = string.Empty;
            string groupLabel = string.Empty;
                
                
            if (string.IsNullOrEmpty(codon.Properties["groupName"]))
            {
                throw new Exception(string.Format("groupName not found in dynamic group:id ={0},name = {1}", codon.Id, codon.Name));
            }
            else
            {
                if (!string.IsNullOrEmpty(codon.Properties["label"]))
                {
                    labelConfig = codon.Properties["label"];
                }

                groupLabel = StringParser.Parse(labelConfig);
                groupName = codon.Properties["groupName"];
                this._dynamicGroups.Add(groupName, codon);
                BarSubItem item = new DevExpress.XtraBars.BarSubItem(this._barManager, groupLabel);
                if (!string.IsNullOrEmpty(codon.Properties["class"]))
                {
                    command = (ICommand)codon.AddIn.CreateObject(codon.Properties["class"]);
                    command.Parameter = groupName;
                }               
                this.AddDynamicContainer(commandId, item, command, codon.Conditions, groupName);
            }
        }

        private void OverrideCommand(Codon codon, MenuItemDescriptor descriptor)
        {
            string cmdId = string.Empty;

            if (string.IsNullOrEmpty(codon.Properties["cmdId"]))
            {
                throw new Exception(string.Format("cmdId not Config in override Commands:id ={0},name={1}", codon.Id, codon.Name));
            }
            else
            {
                cmdId = codon.Properties["cmdId"];
            }
            if (string.IsNullOrEmpty(codon.Properties["class"]))
            {
                throw new Exception(string.Format("class not Config in override Commands:id ={0},name={1}", codon.Id, codon.Name));
            }

            ICommand command = (ICommand)codon.AddIn.CreateObject(codon.Properties["class"]);
            IUICommand uiCommand = this._commands[cmdId];
            if (uiCommand != null)
            {
                uiCommand.OverrideAction(command);
            }
            else
            {
                throw new Exception("Command not found in CommandManager:" + cmdId);
            }

        }

        public void OverrideCommands(string path)
        {
            bool exist = ICSharpCode.Core.AddInTree.ExistsTreeNode(path);
            if (!exist)
            {
                //throw new Exception("Command Not Config:" + path);
                return;
            }

            List<MenuItemDescriptor> descriptors = AddInTree.BuildItems<MenuItemDescriptor>(path, this, false);
            foreach (MenuItemDescriptor item in descriptors)
            {
                Codon codon = item.Codon;
                this.OverrideCommand(codon, item);
            }
        }

        private IUICommand FindCommand(string cmdPath)
        {
            var cmd = this._commands.Where(a => a.Value.RibbonPath == cmdPath).FirstOrDefault();
            return cmd.Value;
        }

        private IUICommand GetContainerCmd(string groupName)
        {
            IUICommand containerCmd = null;
            foreach (KeyValuePair<string, IUICommand> pair in this._commands)
            {
                if (pair.Value.BarItem is BarSubItem && pair.Value.GroupName == groupName)
                {
                    containerCmd = pair.Value;
                    break;
                }
            }
            return containerCmd;
        }

        private List<IUICommand> GetSubCmds(string groupName)
        {
            List<IUICommand> subCmds = new List<IUICommand>();
            foreach (KeyValuePair<string, IUICommand> pair in this._commands)
            {
                if (!(pair.Value.BarItem is BarSubItem) && pair.Value.GroupName == groupName)
                {
                    subCmds.Add(pair.Value);
                }
            }
            return subCmds;
        }
        #endregion

        #region Public Methods     

        //check all command state
        public void UpdateCommandState(Workspaces.IWorkspace1 workSpace)
        {
            foreach (KeyValuePair<string, IUICommand> cmd in this._commands)
            {
                IController controller = this._controllerFinder.FindController(cmd.Value.controllerId);
                
                cmd.Value.CheckConditions(controller,workSpace);
            }
            
        }

        //check specifed command state
        //public void UpdateCommandState(string commandId)
        //{
        //    if (this._commands.ContainsKey(commandId))
        //    {
        //        this._commands[commandId].CheckConditions(this._caller);
        //    }
        //    else 
        //    {
        //        throw new Exception("Command not exist");
        //    }
        //}

        public void LoadCommands(string path)
        {
            bool exist = ICSharpCode.Core.AddInTree.ExistsTreeNode(path);
            if (!exist)
            {
                //throw new Exception("Command Not Config:" + path);
                return;
            }

         
            List<MenuItemDescriptor> descriptors = AddInTree.BuildItems<MenuItemDescriptor>(path, this, false);
            foreach (MenuItemDescriptor item in descriptors)
            {
                Codon codon = item.Codon;
                this.LoadCommand(codon,item);               
            }
        }

        /// <summary>
        /// Update checkForView Command State.
        /// </summary>
        /// <param name="checkForViewId"></param>
        /// <param name="check"></param>
        public void UpdateViewCheckCommandState(string checkForViewId, bool check)
        {
            foreach (KeyValuePair<string, IUICommand> cmdPair in this._commands)
            {
                if (cmdPair.Value.CheckForViewId == checkForViewId)
                {
                    cmdPair.Value.Checked = check;
                }
            }
        }

        
        #endregion

        #region ICommandRegister

        public bool RegisterCommand(BarItem item, string cmdPath, ICommand action, IEnumerable<ICondition> conditions)
        {
            IUICommand cmd = this.FindCommand(cmdPath);
            if (cmd == null)
            {
                MessageService.ShowWarning("Command Register fail:" + cmdPath);
                return false;
            }
         
            cmd.HookCommand(item, action,conditions);
            return true;

        }
        //register dynamic command
        public bool RegisterCommand(BarItem item,string cmdId, string cmdPath, ICommand action, string dynamicGroupName)
        {
            string groupName = dynamicGroupName;
            if (!this._dynamicGroups.ContainsKey(dynamicGroupName))
            {
                throw new Exception("dynamicGroup not found in command manager:" + dynamicGroupName);
            }
            var condon = this._dynamicGroups[dynamicGroupName];
            IUICommand cmd = new UICommand(cmdId, CommandSources.RibbonDynamicGroup, cmdPath, item, action,condon.Conditions, groupName);
            this._commands.Add(cmdId, cmd);
            return true;
        }

        public object owner
        {
            get { return _caller; }
        }
        #endregion

        #region IBarItemFinder
        public BarItem GetBarItem(string commandId)
        {
            if (this._commands.ContainsKey(commandId))
            {
                IUICommand cmd = this._commands[commandId];
                return cmd.BarItem;
            }
            else
            {
                return null;
            }

        }
        public List<BarItem> GetDynamicBarItems(string groupId)
        {
            List<BarItem> items = new List<BarItem>();
            var groups = this._dynamicGroups.Where(c => c.Value.Id == groupId);
            if (groups.Count() > 0)
            {
                string groupName = groups.First().Key;
                var cmds = this._commands.Where(a => a.Value.GroupName == groupName && !(a.Value.BarItem is BarSubItem));
                foreach (var cmd in cmds)
                {
                    items.Add(cmd.Value.BarItem);
                }
            }
            return items;
        }

        public IUICommand GetDynamicContainer(string groupId)
        {
            string groupName = string.Empty;
            var groups = this._dynamicGroups.Where(c => c.Value.Id == groupId);
            if (groups.Count() > 0)
            {
                groupName = groups.First().Key;
            }
            else
            {
                throw new Exception("submenu container not found:" + groupId);
            }
            foreach (KeyValuePair<string, IUICommand> pair in this._commands)
            {
                if (pair.Value.BarItem is BarSubItem && pair.Value.GroupName == groupName)
                {
                    return pair.Value;
                }
            }
            return null;
        }
        #endregion      
    

       
    
        public void Dispose()
        {
            this._commands.Clear();
            this._barManager = null;
            this._caller = null;
            this._controllerFinder = null;
            this._dynamicGroups.Clear();
            
        }



        #region IRunTimeCommandRigister
        public bool ClearOldCommand(string groupName)
        {
            IUICommand containerCmd = this.GetContainerCmd(groupName);
            if (containerCmd == null) throw new Exception("Container cmd not found:" + groupName);
            BarSubItem container = containerCmd.BarItem as BarSubItem;
            container.ItemLinks.Clear();

            List<IUICommand> subCmds = this.GetSubCmds(groupName);
            foreach (IUICommand cmd in subCmds)
            {
                this._barManager.Items.Remove(cmd.BarItem);
                this._commands.Remove(cmd.CommandId);
                cmd.Dispose();
            }        

            return true;
        }

        public bool AddRunTimeCommand(string groupName, string caption, string imgSource, ICommand action,bool check)
        {
            List<ICondition> condtions = new List<ICondition>();
            BarButtonItem item = new BarButtonItem(this._barManager, caption);
            item.ButtonStyle = BarButtonStyle.Check;
            item.Down = check;
            action.Owner = this._controllerFinder.FindController(string.Empty);
            this.RegisterCommand(item,groupName + caption, string.Empty, action, groupName);
            IUICommand containerCmd = this.GetContainerCmd(groupName);
            (containerCmd.BarItem as BarSubItem).ItemLinks.Add(item);
            return true;
        }
        public IControllerFinder ControllerFinder
        {
            get
            {
                return this._controllerFinder;
            }
        }
        #endregion

      
    }
}
