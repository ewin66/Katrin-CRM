using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.Windows.Forms;

namespace Katrin.Win.Common.Controls
{
    public class ProgressTrackBarControl : TrackBarControl
    {
        static ProgressTrackBarControl()
        {
            RepositoryItemProgressTrackBar.Register();
        }
        public override string EditorTypeName
        {
            get { return RepositoryItemProgressTrackBar.EditorName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemProgressTrackBar Properties
        {
            get { return base.Properties as RepositoryItemProgressTrackBar; }
        }
    }


    public class RepositoryItemProgressTrackBar : RepositoryItemTrackBar
    {
        ProgressBarControl _progress;
        public ProgressBarControl Progress
        {
            get { return _progress; }
            set
            {
                if (_progress == value)
                    return;
                if (_progress != null)
                {
                    _progress.PropertiesChanged -= new EventHandler(_progress_PropertiesChanged);
                    _progress.EditValueChanged -= new EventHandler(_progress_PropertiesChanged);
                }
                _progress = value;
                if (_progress != null)
                {
                    _progress.PropertiesChanged += new EventHandler(_progress_PropertiesChanged);
                    _progress.EditValueChanged += new EventHandler(_progress_PropertiesChanged);
                }
                this.OnPropertiesChanged(EventArgs.Empty);
            }
        }

        void _progress_PropertiesChanged(object sender, EventArgs e)
        {
            this.OnPropertiesChanged(EventArgs.Empty);
        }

        public RepositoryItemProgressTrackBar()
            : base()
        {
        }

        internal const string EditorName = "ProgressTrackBar";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(ProgressTrackBarControl),
                typeof(RepositoryItemProgressTrackBar), typeof(ProgressTrackBarViewInfo),
                new TrackBarPainter(), true));
        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }
        public override void Assign(RepositoryItem item)
        {
            base.Assign(item);
            this.Progress = (item as RepositoryItemProgressTrackBar).Progress;
        }
    }

    public class ProgressTrackBarViewInfo : TrackBarViewInfo
    {
        public ProgressTrackBarViewInfo(RepositoryItem item)
            : base(item)
        {

        }
        public override TrackBarObjectPainter GetTrackPainter()
        {
            if (IsPrinting)
                return new TrackBarObjectPainter();
            if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.WindowsXP)
                return new WindowsXPTrackBarObjectPainter();
            if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin)
                return new SkinProgressTrackBarObjectPainter(LookAndFeel.ActiveLookAndFeel);
            if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Office2003)
                return new Office2003TrackBarObjectPainter();
            return new TrackBarObjectPainter();

        }

    }

    public class SkinProgressTrackBarObjectPainter : SkinTrackBarObjectPainter
    {
        public SkinProgressTrackBarObjectPainter(ISkinProvider provider) : base(provider) { }
        protected override void DrawLine(TrackBarObjectInfoArgs e, System.Drawing.Point p1, System.Drawing.Point p2)
        {
            base.DrawLine(e, p1, p2);
        }
        public override void DrawTrackLine(TrackBarObjectInfoArgs e)
        {
            Rectangle rec = e.ViewInfo.TrackBarHelper.Rotate(e.ViewInfo.TrackLineRect);
            rec.X = e.ViewInfo.PointsRect.X;
            rec.Width = e.ViewInfo.PointsRect.Width;

            ProgressBarControl prb = (e.ViewInfo.Item as RepositoryItemProgressTrackBar).Progress;
            if (prb == null)
            {
                base.DrawTrackLine(e);
                return;
            }
            BaseControlViewInfo vi = prb.GetViewInfo();
            vi.CalcViewInfo(e.Graphics, MouseButtons.None, Point.Empty, rec);
            ControlGraphicsInfoArgs args = new ControlGraphicsInfoArgs(vi, e.Cache, rec);
            vi.Painter.Draw(args);
        }
    }
}
