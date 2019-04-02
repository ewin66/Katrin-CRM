using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework.Test
{
    [Export]
    public partial class ShellForm : RibbonForm, IShell
    {
        public ShellForm()
        {
            InitializeComponent();
            InitSkinGallery();
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        [Import(AllowDefault=true)]
        public IPartManager<IMenuPart> Menus { get; set; }

        public void CanClose(Action<bool> callback)
        {
            throw new NotImplementedException();
        }

        public void TryClose()
        {
            throw new NotImplementedException();
        }

        private void ShellForm_Load(object sender, EventArgs e)
        {

        }
    }
}
