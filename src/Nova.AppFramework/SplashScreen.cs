using DevExpress.XtraEditors;
using Katrin.AppFramework.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework
{
    public class SplashScreenForm : XtraForm
    {
        private const int PaddingValue = 10;
        public SplashScreenForm(string displayText)
            : base()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.HelpButton = false;
            this.ShowInTaskbar = true;
            this.Text = Application.ProductName;
            this.Tag = null;
            NativeMethods.SetExecutingApplicationIcon(this);
            Panel place = new Panel();
            place.Location = new Point(0, 0);
            place.Dock = DockStyle.Fill;
            place.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(place);
            Label waitLabel = new Label();
            waitLabel.AutoSize = true;
            waitLabel.Location = new System.Drawing.Point(PaddingValue, PaddingValue);
            if (string.IsNullOrEmpty(displayText))
            {
                displayText = "Loading";
            }
            waitLabel.Text = displayText;
            place.Controls.Add(waitLabel);
            PictureBox picture = new PictureBox();
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.Image = this.Icon.ToBitmap();
            picture.Location = new System.Drawing.Point(PaddingValue, PaddingValue);
            place.Controls.Add(picture);
            waitLabel.Location = new Point(picture.Left + picture.Width + PaddingValue, (picture.Height - waitLabel.Height) / 2 + PaddingValue);
            this.Size = new Size(waitLabel.Left + waitLabel.Width + PaddingValue, waitLabel.Top * 2 + waitLabel.Height);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
        }
    }

    public interface ISplash
    {
        void Start();
        void Stop();
        bool IsStarted { get; }
        void SetDisplayText(string displayText);
    }

    public class SplashScreen : ISplash
    {
        static private SplashScreenForm form;
        private static string caption;
        private static bool isStarted = false;
        #region ISplash Members
        public void Start()
        {
            isStarted = true;
            form = new SplashScreenForm(caption);
            form.Show();
            Application.DoEvents();
        }
        public void Stop()
        {
            if (form != null)
            {
                form.Hide();
                form.Close();
                form = null;
            }
            isStarted = false;
        }
        public void SetDisplayText(string displayText)
        {
            caption = displayText;
        }
        public bool IsStarted
        {
            get
            {
                return isStarted;
            }
        }
        #endregion
    }
}
