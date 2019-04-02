using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework.Utils
{
    public static class NativeMethods
    {
        private const int SW_RESTORE = 9;
        private static bool extractIconFromExecutable = true;
        private static bool alreadyExtracted = false;
        private static Icon exeIconLarge;
        private static Icon exeIconSmall;
        private static void ExtractExeIcons()
        {
            if (extractIconFromExecutable && !alreadyExtracted)
            {
                alreadyExtracted = true;
                IntPtr smallIcon = IntPtr.Zero;
                IntPtr largeIcon = IntPtr.Zero;
                int resultIconCount = ExtractIconEx(Application.ExecutablePath, 0, ref largeIcon, ref smallIcon, 1);
                if (resultIconCount > 0)
                {
                    if (largeIcon != IntPtr.Zero)
                    {
                        exeIconLarge = (Icon)Icon.FromHandle(largeIcon).Clone();
                        DestroyIcon(ref largeIcon);
                    }
                    if (smallIcon != IntPtr.Zero)
                    {
                        exeIconSmall = (Icon)Icon.FromHandle(smallIcon).Clone();
                        DestroyIcon(ref smallIcon);
                    }
                }
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(ref IntPtr handle);
        [DllImport("SHELL32.DLL", EntryPoint = "ExtractIconEx", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 ExtractIconEx(string lpszFile, Int32 nIconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, Int32 nIcons);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        public static void SetFormIcon(Form form, Image smallImage, Image largeImage)
        {
            Icon smallIcon = null;
            if (smallImage != null)
            {
                smallIcon = Icon.FromHandle(new Bitmap(smallImage).GetHicon());
            }
            Icon largeIcon = null;
            if (largeImage != null)
            {
                largeIcon = Icon.FromHandle(new Bitmap(largeImage).GetHicon());
            }
            SetFormIcon(form, smallIcon, largeIcon);
        }
        public static void SetFormIcon(Form form, Icon smallIcon, Icon largeIcon)
        {
            if (largeIcon != null)
            {
                form.Icon = largeIcon;
            }
            if (smallIcon != null)
            {
                FieldInfo fi = typeof(Form).GetField("smallIcon", BindingFlags.SetField | BindingFlags.Instance | BindingFlags.NonPublic);
                if (fi != null)
                    fi.SetValue(form, smallIcon);
                MethodInfo mi = typeof(Form).GetMethod("UpdateWindowIcon", BindingFlags.Instance | BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(form, new object[] { true });
                }
            }
        }
        public static void SetExecutingApplicationIcon(Form form)
        {
            SetFormIcon(form, ExeIconSmall, ExeIconLarge);
        }
        public static bool IsCtrlShiftPressed()
        {
            Keys keys = Control.ModifierKeys;
            return
                (((keys & Keys.Shift) == Keys.Shift) || ((keys & Keys.ShiftKey) == Keys.ShiftKey))
                &&
                (((keys & Keys.Control) == Keys.Control) || ((keys & Keys.ControlKey) == Keys.ControlKey));
        }
        public static Icon ExeIconLarge
        {
            get
            {
                ExtractExeIcons();
                return exeIconLarge != null ? (Icon)exeIconLarge.Clone() : null;
            }
        }
        public static Icon ExeIconSmall
        {
            get
            {
                ExtractExeIcons();
                return exeIconSmall != null ? (Icon)exeIconSmall.Clone() : null;
            }
        }
        public static bool ExtractIconFromExecutable
        {
            get { return extractIconFromExecutable; }
            set { extractIconFromExecutable = value; }
        }
        public static bool RestoreForm(Form form)
        {
            return ShowWindow(form.Handle, SW_RESTORE);
        }
    }
}
