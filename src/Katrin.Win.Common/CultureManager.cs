using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Katrin.Win.Common
{
    public class CultureManager
    {
        public static CultureInfo CurrentCulture
        {
            get
            {
                var language = ConfigurationManager.AppSettings["Language"];
                if (!string.IsNullOrEmpty(language))
                {
                    try
                    {
                        return new CultureInfo(language);
                    }
                    catch
                    {
                    }
                }
                return new CultureInfo(1033);
            }
        }
    }
}
