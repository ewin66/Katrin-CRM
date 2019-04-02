using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.RibbonBuilder;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.AppFramework.WinForms.CommandManage
{
    /// <summary>
    /// UICommand
    /// author:hecq
    /// date:2012-11-?
    /// </summary>
    class UICommand : IUICommand
    {
        #region Private members
        private BarItem _barItem;
        private ICommand _actionCommand;
        private List<ICondition> _conditions;
        private string _commandId;
        private string _checkForViewId;
        private CommandSources _source;
        private string _ribbonPath;
        private string _groupName;
        private string _controllerId = string.Empty;
        private IControllerFinder _controllerFinder;
        private IRunTimeCommandRigister _runTimeCommandRigister;

        #endregion

        #region Constructor
        /// <summary>
        /// ribbon command init
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="ribbonPath"></param>
        /// <param name="source"></param>
        /// <param name="checkForViewId"></param>
        public UICommand(string commandId,
           string ribbonPath,
            CommandSources source,
            string checkForViewId
          )
        {
            this._conditions = new List<ICondition>();
            this._commandId = commandId;
            this._ribbonPath = ribbonPath;
            this._source = source;
            this._checkForViewId = checkForViewId;
        }

        /// <summary>
        /// custom command init
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="source"></param>
        /// <param name="checkForViewId"></param>
        /// <param name="item"></param>
        /// <param name="action"></param>
        public UICommand(string commandId,
          CommandSources source,
          string checkForViewId,
            BarItem item,
            ICommand action,
            IEnumerable<ICondition> conditions,
            IControllerFinder finder
        )
        {
            this._controllerFinder = finder;
            this._conditions = new List<ICondition>();
            this._commandId = commandId;
            this._ribbonPath = string.Empty;
            this._source = source;
            this._checkForViewId = checkForViewId;
            this._barItem = item;
            this._actionCommand = action;
            this._conditions.AddRange(conditions);
            this.BarItem.ItemClick += _barItem_ItemClick;
        }

        /// <summary>
        /// dynamic command init
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="source"></param>
        /// <param name="checkForViewId"></param>
        /// <param name="item"></param>
        /// <param name="action"></param>
        /// <param name="groupName"></param>
        public UICommand(string commandId,
        CommandSources source,
        string ribbonPath,
          BarItem item,
          ICommand action,
            IEnumerable<ICondition> conditions,
            string groupName)
        {
            this._conditions = new List<ICondition>();
            this._commandId = commandId;
            this._ribbonPath = string.Empty;
            this._source = source;
            this._checkForViewId = string.Empty;
            this._ribbonPath = ribbonPath;
            this._barItem = item;
            this._actionCommand = action;
            this.BarItem.ItemClick += _barItem_ItemClick;
            this._groupName = groupName;
            this._conditions.AddRange(conditions);
        }

        /// <summary>
        /// dynamic command init
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="source"></param>
        /// <param name="checkForViewId"></param>
        /// <param name="item"></param>
        /// <param name="action"></param>
        /// <param name="groupName"></param>
        public UICommand(string commandId,
        CommandSources source,       
          BarSubItem item,
          ICommand action,
            IEnumerable<ICondition> conditions,
            string groupName,
            IRunTimeCommandRigister cmdRegister,
            IControllerFinder finder)
        {
            this._conditions = new List<ICondition>();
            this._commandId = commandId;
            this._ribbonPath = string.Empty;
            this._source = source;
            this._checkForViewId = string.Empty;
            this._ribbonPath = string.Empty;
            this._barItem = item;
            this._actionCommand = action;           
            this.BarItem.ItemClick+= _barItem_ItemClick;
            this._groupName = groupName;
            this._conditions.AddRange(conditions);
            this._runTimeCommandRigister = cmdRegister;
            this._controllerFinder = finder;
        }
        #endregion


        #region Private Methods
        void _barItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Excute();
        }

        private void SetConditionAffectedProperty(ConditionAffect affectType, Action<ConditionFailedAction> action, object caller)
        {
            var condtions = _conditions.OfType<Condition>().Where(c => c.Properties.Get("affect", ConditionAffect.Nothing) == affectType);
            if (!condtions.Any()) return;
            var failedAction = Condition.GetFailedAction(condtions, caller);
            action(failedAction);
        }

        
        #endregion

        #region IUICommand

        public string CommandId
        {
            get
            {
                return this._commandId;
            }
        }

        public string CheckForViewId
        {
            get
            {
                return this._checkForViewId;
            }
        }

        public bool CanCheck
        {
            get
            {
                if (this._barItem == null)
                {
                    throw new Exception("Command button not initialization");
                }

                if (!(this._barItem is BarButtonItem))
                {
                    return false;
                }

                BarButtonItem buttonItem = this._barItem as BarButtonItem;
                if (buttonItem.ButtonStyle == BarButtonStyle.Check)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Checked
        {
            get
            {
                if (this._barItem == null)
                {
                    return false;
                }
                if (!(this._barItem is BarBaseButtonItem))
                {

                    return false;
                }

                BarButtonItem buttonItem = this._barItem as BarButtonItem;
                if (buttonItem.ButtonStyle != BarButtonStyle.Check)
                {
                    return false;
                }
                return buttonItem.Down;
            }
            set
            {
                if (this._barItem == null)
                {
                    return;
                }
                if (!(this._barItem is BarButtonItem))
                {

                    return;
                }

                BarButtonItem buttonItem = this._barItem as BarButtonItem;
                if (buttonItem.ButtonStyle != BarButtonStyle.Check)
                {
                    return;
                }
                buttonItem.Down = value;
            }
        }

        public bool Visualble
        {
            get
            {
                if (this._barItem != null)
                {
                    if (this._barItem.Links.Count > 0)
                    {
                        return this._barItem.Links[0].Visible;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (this._barItem != null)
                {
                    foreach (BarItemLink link in this._barItem.Links)
                    {
                        link.Visible = value;
                    }
                }
                else
                {
                    throw new Exception("Command button not initialization");
                }
            }
        }

        public bool Enable
        {
            get
            {
                if (this._barItem != null)
                {
                    return this._barItem.Enabled;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (this._barItem != null)
                {
                    this._barItem.Enabled = value;
                }
                else
                {
                    throw new Exception("Command button not initialization");
                }
            }
        }

        public ICSharpCode.Core.ICommand ActionCommand
        {
            get
            {
                return this._actionCommand;
            }
        }
        public BarItem BarItem
        {
            get { return this._barItem; }
        }
        public bool Excute()
        {
            if (this._controllerFinder != null && this._actionCommand != null)
            {
               this._actionCommand.Owner = this._controllerFinder.FindController(this._controllerId);
            }
            if (this.IsRunTimeContainer)
            {
                this._actionCommand.Owner = this._runTimeCommandRigister;
            }
            if (this.Enable)
            {
                if(this._actionCommand !=null) this._actionCommand.Run();
                return true;
            }
            return false;
        }
        public void HookCommand(BarItem barItem, ICSharpCode.Core.ICommand actionCommand, IEnumerable<ICondition> conditions)
        {
            _actionCommand = actionCommand;
            _barItem = barItem;
            this._conditions.Clear();
            this._conditions.AddRange(conditions);
            _barItem.ItemClick += _barItem_ItemClick;
        }

    
        public void CheckConditions(IController controller, Workspaces.IWorkspace1 workSpace)
        {
            SetConditionAffectedProperty(ConditionAffect.Enabled,
                a => this._barItem.Enabled = a == ConditionFailedAction.Nothing,
                controller);
            SetConditionAffectedProperty(ConditionAffect.Visibility, a =>
            {
                if (a == ConditionFailedAction.Nothing)
                    this._barItem.Visibility = BarItemVisibility.Always;
                else
                    this._barItem.Visibility = BarItemVisibility.Never;
                if (!(this._barItem is BarButtonItemEx)) return;
                var barButtonItem = this._barItem as BarButtonItemEx;
                var page = barButtonItem.FormRibbon.Pages.Cast<RibbonPage>()
                      .Where(c => c.Groups.Cast<RibbonPageGroup>()
                          .Any(d => d.ItemLinks.Cast<BarItemLink>()
                              .Any(e => e.Item == barButtonItem)
                              )
                              );
                if (page == null) return;
                if (page.Count() <= 0) return;
                var group = page.First().Groups.Cast<RibbonPageGroup>()
                    .Where(d => d.ItemLinks.Cast<BarItemLink>()
                        .Any(e => e.Item == barButtonItem)
                        );
                if (group == null) return;
                if (group.Count() <= 0) return;
                group.First().Visible = group.First().ItemLinks.Cast<BarButtonItemLink>().Any(c => c.Item.Visibility == BarItemVisibility.Always);
            },
            controller);

            if (!(this._barItem is BarButtonItem))
            {
                return;
            }

            BarButtonItem buttonItem = this._barItem as BarButtonItem;
            if (buttonItem.ButtonStyle == BarButtonStyle.Check)
            {
                SetConditionAffectedProperty(ConditionAffect.Down,
                    a => buttonItem.Down = a == ConditionFailedAction.Nothing,
                   workSpace);
            }
        }
        public IList<ICondition> Conditions
        {
            get { return this._conditions; }
        }
        public void AddConditon(ICondition condition)
        {
            this._conditions.Add(condition);
        }

        public CommandSources Source
        {
            get { return _source; }
        }

        public string RibbonPath
        {
            get { return this._ribbonPath; }
        }
        public string GroupName
        {
            get { return this._groupName; }
        }

        public string controllerId
        {
            get
            {
                return _controllerId;
            }
            set
            {
                _controllerId = value;
            }
        }
        public bool IsRunTimeContainer
        {
            get 
            {
                if (this.BarItem is BarSubItem && this._actionCommand != null)
                {
                    return true;
                }
                return false;
            }
        }
        public void OverrideAction(ICommand action)
        {
            this._actionCommand = action;
        }
        #endregion

        public void Dispose()
        {
            this._barItem.Dispose();
        }


       
    }
}
