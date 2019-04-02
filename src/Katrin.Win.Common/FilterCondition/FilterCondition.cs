using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
namespace Katrin.Win.Common.FilterCondition
{
    [Serializable()]
    public class FilterCondition
    {
        private string filteName;
        public string FilteName
        {
            get;
            set;
        }

        private string name;

        public string Name
        {
            get;
            set;
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
    }
}
