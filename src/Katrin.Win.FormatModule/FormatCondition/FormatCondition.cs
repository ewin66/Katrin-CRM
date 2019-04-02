using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
namespace Katrin.Win.FormatModule.FormatCondition
{
    [Serializable()]
    public class FormatCondition
    {
        private string name;

        public string Name
        {
            get;
            set;
        }

        public string ConditionName
        {
            get;
            set;
        }
        
        public Color Backcolor
        {
            get;
            set;
        }

        public int BackcolorArgb
        {
            get { return Backcolor.ToArgb(); }
            set { Backcolor = Color.FromArgb(value); }
        }

        private Color forecolor;

        public Color Forecolor
        {
            get;
            set;
        }

        public int ForecolorArgb
        {
            get { return Forecolor.ToArgb(); }
            set { Forecolor = Color.FromArgb(value); }
        }

        private string fontName;

        public string FontName
        {
            get { return fontName; }
            set { fontName = value; }
        }

        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }


        private bool bold;

        public bool Bold
        {
            get { return bold; }
            set { bold = value; }
        }

        private bool unit;

        public bool Unit
        {
            get { return unit; }
            set { unit = value; }
        }


        private bool italic;

        public bool Italic
        {
            get { return italic; }
            set { italic = value; }
        }


        private bool underline;

        public bool Underline
        {
            get { return underline; }
            set { underline = value; }
        }


        private string conditions;

        public string Conditions
        {
            get { return conditions; }
            set { conditions = value; }
        }

        private bool active = true;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
       
        public bool UseFont { get; set; }
        public bool UseForeColor { get; set; }
        public bool UseBackColor { get; set; }
    }
}
