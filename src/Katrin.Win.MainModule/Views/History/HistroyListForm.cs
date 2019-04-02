using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.Utils;
using System.Reflection;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;

namespace Katrin.Win.MainModule.Views.History
{
    [SmartPart]
    public partial class HistroyListForm : XtraForm
    {
        public HistroyListForm()
        {
            InitializeComponent();
        }
        public HistoryListView FormHistoryListView
        {
            get { return this.historyListView; }
        }
    }
}
