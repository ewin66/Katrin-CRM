using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework
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

        public static void SetLaguage(string language)
        {        
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Language"].Value = language;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
