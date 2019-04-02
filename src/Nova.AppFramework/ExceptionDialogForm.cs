using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework
{
    public class ButtonsLayouter
    {
        public const int ButtonHeight = 22;
        public const int ButtonTextIndent = 15;
    }

    public partial class ExceptionDialogForm : XtraForm
    {
        const int Spacing = 12;
        const string labelTextAttributeName = "ExceptionDialogLabel";
        private string labelText;
        private const int memoHeigth = 70;
        private const int memoWidth = 400;
        private string messageText;
        MemoEdit messageMemo;
        Rectangle iconRectangle;
        Rectangle messageRectangle;
        Icon icon;
        SimpleButton[] buttons;
        public UserLookAndFeel GetLookAndFeel()
        {
            XtraForm form = Owner as XtraForm;
            if (form != null)
                return form.LookAndFeel;
            return null;
        }
        private ExceptionDialogForm()
        {
            InitializeComponent();
            labelText = "The following error occurred";
            icon = SystemIcons.Error;
        }

        public static void ShowMessage(string caption, string exceptionMessage)
        {
            ExceptionDialogForm form = new ExceptionDialogForm();
            form.ShowMessageBoxDialog(caption, exceptionMessage);
        }
        private void ShowMessageBoxDialog(string caption, string exceptionMessage)
        {
            this.Text = caption;
            this.messageText = exceptionMessage;
            if (GetLookAndFeel() != null)
                LookAndFeel.Assign(GetLookAndFeel());
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
            IWin32Window owner = Owner;
            if (owner == null)
            {
                Form activeForm = Form.ActiveForm;
                if (activeForm != null && !activeForm.InvokeRequired)
                {
                    owner = activeForm;
                }
            }
            if (owner != null)
            {
                Control ownerControl = owner as Control;
                if (ownerControl != null)
                {
                    if (!ownerControl.Visible)
                    {
                        owner = null;
                    }
                    else
                    {
                        Form ownerForm = ownerControl.FindForm();
                        if (ownerForm != null)
                        {
                            if ((!ownerForm.Visible)
                                || ownerForm.WindowState == FormWindowState.Minimized
                                || ownerForm.Right <= 0
                                || ownerForm.Bottom <= 0)
                            {
                                owner = null;
                            }
                        }
                    }
                }
            }
            if (owner == null)
            {
                ShowInTaskbar = true;
                StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.CenterParent;
            }
            CreateButtons();
            CalcIconBounds();
            CalcMessageBounds();
            CreateMemo();
            CalcFinalSizes();
            Form frm = owner as Form;
            if (frm != null && frm.TopMost)
                this.TopMost = true;
            ShowDialog(owner);
        }
        void CalcMessageBounds()
        {
            int messageTop, messageLeft, messageWidth, messageHeight;
            messageTop = Spacing;
            messageLeft = (icon == null) ? Spacing : (this.iconRectangle.Left + this.iconRectangle.Width + Spacing);
            int maxFormWidth = this.MaximumSize.Width;
            if (maxFormWidth <= 0)
                maxFormWidth = SystemInformation.WorkingArea.Width;
            int maxTextWidth = maxFormWidth - Spacing - messageLeft;
            if (maxTextWidth < 10)
                maxTextWidth = 10;
            GraphicsInfo ginfo = new GraphicsInfo();
            ginfo.AddGraphics(null);
            SizeF textSize = GetPaintAppearance().CalcTextSize(ginfo.Graphics, labelText, maxTextWidth);
            ginfo.ReleaseGraphics();
            messageWidth = (int)Math.Ceiling(textSize.Width);
            int maxFormHeight = this.MaximumSize.Height;
            if (maxFormHeight <= 0)
                maxFormHeight = SystemInformation.WorkingArea.Height;
            int maxTextHeight = maxFormHeight - Spacing - ButtonsLayouter.ButtonHeight - Spacing - messageTop - SystemInformation.CaptionHeight;
            if (maxTextHeight < 10)
                maxTextHeight = 10;
            messageHeight = (int)Math.Ceiling(textSize.Height);
            if (messageHeight > maxTextHeight)
                messageHeight = maxTextHeight;
            messageWidth = messageWidth < memoWidth ? memoWidth : messageWidth;
            this.messageRectangle = new Rectangle(messageLeft, messageTop, messageWidth, messageHeight);
        }
        void CalcIconBounds()
        {
            this.iconRectangle = new Rectangle(Spacing, Spacing, icon.Width, icon.Height);
        }
        void CreateButtons()
        {
            buttons = new SimpleButton[1];
            Int64 i = 0;
            SimpleButton currentButton = new SimpleButton();
            currentButton.LookAndFeel.Assign(LookAndFeel);
            buttons[i] = currentButton;
            currentButton.DialogResult = DialogResult.OK;
            currentButton.Text = Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxOkButtonText);
            this.Controls.Add(currentButton);
            if (buttons.Length == 1)
                this.CancelButton = buttons[0];
            buttons[0].Select();
        }
        void CreateMemo()
        {
            this.messageMemo = new MemoEdit();
            messageMemo.Location = new Point(this.messageRectangle.Left, this.messageRectangle.Bottom + Spacing);
            messageMemo.Size = new Size(memoWidth, memoHeigth);
            messageMemo.Text = messageText;
            messageMemo.Properties.ReadOnly = true;
            this.Controls.Add(this.messageMemo);
        }
        void CalcFinalSizes()
        {
            int buttonsTotalWidth = 0;
            foreach (SimpleButton button in buttons)
            {
                if (buttonsTotalWidth != 0)
                    buttonsTotalWidth += Spacing;
                buttonsTotalWidth += button.Width;
            }
            int buttonsTop = this.messageRectangle.Bottom + 2 * Spacing;
            int wantedFormWidth = this.MinimumSize.Width;
            if (wantedFormWidth == 0)
                wantedFormWidth = SystemInformation.MinimumWindowSize.Width;
            int messageRectangleRight = this.messageRectangle.Right;
            if (messageRectangleRight < memoWidth)
            {
                messageRectangleRight = memoWidth;
            }
            if (wantedFormWidth < messageRectangleRight + Spacing)
                wantedFormWidth = messageRectangleRight + Spacing;
            if (wantedFormWidth < buttonsTotalWidth + Spacing + Spacing)
                wantedFormWidth = buttonsTotalWidth + Spacing + Spacing;
            GraphicsInfo ginfo = new GraphicsInfo();
            ginfo.AddGraphics(null);
            try
            {
                using (StringFormat fmt = TextOptions.DefaultStringFormat.Clone() as StringFormat)
                {
                    fmt.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                    using (Font captionFont = ControlUtils.GetCaptionFont())
                    {
                        int maxCaptionForcedWidth = SystemInformation.WorkingArea.Width / 3 * 2;
                        int captionTextWidth = 1 + 4 + (int)ginfo.Cache.CalcTextSize(this.Text, captionFont, fmt, 0).Width;
                        int captionTextWidthWithButtonsAndSpacing = captionTextWidth + SystemInformation.CaptionButtonSize.Width * 5 / 4;
                        int captionWidth = Math.Min(maxCaptionForcedWidth, captionTextWidthWithButtonsAndSpacing);
                        if (wantedFormWidth < captionWidth)
                            wantedFormWidth = captionWidth;
                    }
                }
            }
            finally
            {
                ginfo.ReleaseGraphics();
            }
            this.Width = wantedFormWidth + 2 * SystemInformation.FixedFrameBorderSize.Width;
            this.Height = memoHeigth + buttonsTop + buttons[0].Height + Spacing + 2 * SystemInformation.FixedFrameBorderSize.Height + SystemInformation.CaptionHeight;
            int nextButtonPos = (this.Width - buttonsTotalWidth) / 2;
            for (int i = 0; i < buttons.Length; ++i)
            {
                buttons[i].Location = new Point(nextButtonPos, buttonsTop + memoHeigth);
                nextButtonPos += buttons[i].Width + Spacing;
            }
            if (icon == null)
            {
                this.messageRectangle.Offset((wantedFormWidth - (messageRectangleRight + Spacing)) / 2, 0);
            }
            if (icon != null && this.messageRectangle.Height < this.iconRectangle.Height)
            {
                this.messageRectangle.Offset(0, (this.iconRectangle.Height - this.messageRectangle.Height) / 2);
            }
        }
        public string MessageText
        {
            get
            {
                return messageText;
            }
        }
        AppearanceObject GetPaintAppearance()
        {
            AppearanceObject paintAppearance = new AppearanceObject(Appearance, DefaultAppearance);
            paintAppearance.TextOptions.WordWrap = WordWrap.Wrap;
            paintAppearance.TextOptions.VAlignment = VertAlignment.Top;
            paintAppearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            return paintAppearance;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsCache gcache = new GraphicsCache(e))
            {
                gcache.Graphics.DrawIcon(icon, this.iconRectangle);
                GetPaintAppearance().DrawString(gcache, labelText, this.messageRectangle);
            }
        }
    }
}
