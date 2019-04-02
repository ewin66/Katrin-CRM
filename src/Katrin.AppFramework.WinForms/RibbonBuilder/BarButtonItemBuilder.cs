
using DevExpress.XtraBars;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.Core;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.AppFramework.WinForms.RibbonBuilder
{
    public enum ConditionAffect
    {
        Nothing,
        Visibility,
        Enabled,
        Down
    }

    public class BarButtonItemBuilder : AbstractPartBuilder
    {
        
        public override object Build(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            var item = new BarButtonItemEx(codon, caller, conditions);
            return item;
        }
    }

    public class BarButtonItemEx : BarButtonItem, IListener<UpdateRibbonItemMessage>
    {
        private IEnumerable<ICSharpCode.Core.ICondition> _conditions;
        private object _caller;
        private string _objectName;
        public BarButtonItemEx(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            _conditions = conditions;
            _caller = caller;

            var label = codon.Properties["label"] ?? codon.Id;
            Name = codon.Id;

            Caption = StringParser.Parse(label);
            SetRibbonStyle(codon);
            SetButtonStyle(codon);
            SetBeginGroup(codon);
            SetItemClick(codon);
            SetItemGlyph(codon);
           // EventAggregationManager.AddListener(this);
        }

        private void SetButtonStyle(ICSharpCode.Core.Codon codon)
        {
            if (string.IsNullOrEmpty(codon.Properties["ButtonStyle"])) return;
            if (codon.Properties["ButtonStyle"] == "Check")
            {
                ButtonStyle = BarButtonStyle.Check;
            }
        }

        public RibbonControl FormRibbon
        {
            get
            {
                return this.Ribbon;
            }
        }

        private void SetRibbonStyle(ICSharpCode.Core.Codon codon)
        {
            if (string.IsNullOrEmpty(codon.Properties["RibbonStyle"])) return;
            if (codon.Properties["RibbonStyle"].ToString() == "Small")
            {
                RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
                    | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            }
        }

        public bool BeginGroup { get; set; }
        private void SetBeginGroup(ICSharpCode.Core.Codon codon)
        {
            if (string.IsNullOrEmpty(codon.Properties["beginGroup"])) return;
            if (codon.Properties["beginGroup"].ToString() != "true") return;
            BeginGroup = true;
        }

        private void SetItemClick(ICSharpCode.Core.Codon codon)
        {
            if (string.IsNullOrEmpty(codon.Properties["class"])) return;
            var command = (ICommand)codon.AddIn.CreateObject(codon.Properties["class"]);
            if (command == null) return;
            command.Owner = _caller;
            command.Parameter = codon.Properties["Parameter"];
            this.Tag = command;
            //ItemClick += (s, e) =>
            //{
            //    command.Run();
            //};
        }

        private void SetItemGlyph(ICSharpCode.Core.Codon codon)
        {
            string imageName = codon.Properties["imageName"];
            string overlayName = codon.Properties["overlay"];
            PropertyInfo objectNamePro = _caller.GetType().GetProperty("ObjectName");
            if (objectNamePro != null) _objectName = objectNamePro.GetValue(_caller, null) as string;
            if (string.IsNullOrEmpty(imageName)) imageName = _objectName;

            if (string.IsNullOrEmpty(imageName)) return;
            var icon = WinFormsResourceService.GetIcon(imageName.ToLower());

            if (icon == null) return;
            Image largeImage = icon.ToBitmap();
            

            if (!string.IsNullOrEmpty(overlayName))
            {
                var overlay = WinFormsResourceService.GetBitmap(overlayName.ToLower());
                if (overlay != null)
                    DrawOverlay(largeImage, overlay);
            }
            LargeGlyph = largeImage;
            Glyph = new Bitmap(largeImage, new Size(16, 16));
        }

        private void DrawOverlay(Image image, Image overlay)
        {
            if (overlay == null) return;
            using (var canvas = Graphics.FromImage(image))
            {
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                int x = image.Width - overlay.Width;
                int y = image.Height - overlay.Height;
                canvas.DrawImage(overlay, x, y);
                canvas.Save();
            }
        }

        void IListener<UpdateRibbonItemMessage>.Handle(UpdateRibbonItemMessage message)
        {
            var objectAware = _caller as IObjectAware;
            if (objectAware != null && message.ObjectName != objectAware.ObjectName)
            {
                return;
            }

            if (!string.IsNullOrEmpty(message.ItemName) && message.ItemName != Name) return;

            if (!_conditions.Any()) return;


            SetConditionAffectedProperty(ConditionAffect.Enabled, a => Enabled = a == ConditionFailedAction.Nothing,_caller);
            SetConditionAffectedProperty(ConditionAffect.Visibility, a =>
                {
                    if (a == ConditionFailedAction.Nothing)
                        Visibility = BarItemVisibility.Always;
                    else
                        Visibility = BarItemVisibility.Never;
                    var page = this.Ribbon.Pages.Cast<RibbonPage>()
                        .Where(c => c.Groups.Cast<RibbonPageGroup>()
                            .Any(d => d.ItemLinks.Cast<BarButtonItemLink>()
                                .Any(e => e.Item == this)
                                )
                                );
                    if (page == null) return;
                    if (page.Count() <= 0) return;
                    var group = page.First().Groups.Cast<RibbonPageGroup>()
                        .Where(d=>d.ItemLinks.Cast<BarButtonItemLink>()
                            .Any(e=>e.Item == this)
                            );
                    if (group == null) return;
                    if (group.Count() <= 0) return;
                    group.First().Visible = group.First().ItemLinks.Cast<BarButtonItemLink>().Any(c => c.Item.Visibility == BarItemVisibility.Always);
                }, _caller);
                

            if (ButtonStyle == BarButtonStyle.Check)
            {
                SetConditionAffectedProperty(ConditionAffect.Down, a => Down = a == ConditionFailedAction.Nothing, Ribbon.Parent);
            }
        }

        private void SetConditionAffectedProperty(ConditionAffect affectType, Action<ConditionFailedAction> action, object caller)
        {
            var condtions = _conditions.OfType<Condition>().Where(c => c.Properties.Get("affect", ConditionAffect.Nothing) == affectType);
            if (!condtions.Any()) return;
            var failedAction = Condition.GetFailedAction(condtions, caller);
            action(failedAction);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                EventAggregationManager.RemoveListener(this);
            }
           
          
        }
    }

}
