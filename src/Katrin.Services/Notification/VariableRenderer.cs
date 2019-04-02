using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr4.StringTemplate;

namespace Katrin.Services.Notification
{
    public class VariableRenderer : IAttributeRenderer
    {
        string dateFormat;
        string decimalFormat;
        IFormatProvider formatProvider;

        public VariableRenderer(string dateFormat, string decimalFormat, IFormatProvider provider)
        {
            this.dateFormat = dateFormat;
            this.decimalFormat = decimalFormat;
            this.formatProvider = provider;
        }

        public String ToString(Object o)
        {
            String result = null;
            String format = null;
            try
            {
                if (o is DateTime)
                {
                    format = dateFormat;
                    result = ((DateTime)o).ToString(format, formatProvider);
                }
                else if (o is double)
                {
                    format = decimalFormat;
                    result = ((double)o).ToString(format, formatProvider);
                }
                else if (o is decimal)
                {
                    format = decimalFormat;
                    result = ((decimal)o).ToString(format, formatProvider);
                }
                else {
                    result = o.ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Failed to format {0} value \"{1}\" with the format \"{2}\".", o.GetType().Name, o, format), e);
            }
            return result;
        }

        public String ToString(Object o, String formatName)
        {
            String result = null;
            try
            {
                if (o is String)
                {
                    if (formatName.Equals("ToUpper"))
                    {
                        result = o.ToString().ToUpper();
                    }
                    else if (formatName.Equals("ToLower"))
                    {
                        result = o.ToString().ToLower();
                    }
                    else if (formatName.Equals("Trim"))
                    {
                        result = o.ToString().Trim();
                    }
                    else if (formatName.StartsWith("Left("))
                    {
                        int size = Convert.ToInt32(formatName.Substring(5).Trim(new char[] { '(', ')', ' ' }));
                        result = o.ToString().Trim();
                    }
                    else if (formatName.Equals("Right("))
                    {
                        int size = Convert.ToInt32(formatName.Substring(6).Trim(new char[] { '(', ')', ' ' }));
                        result = o.ToString().Trim();
                    }
                    else
                        result = o.ToString();
                }
                else if (o is DateTime)
                {
                    result = ((DateTime)o).ToString(formatName, formatProvider);
                }
                else if (o is double)
                {
                    result = ((double)o).ToString(formatName, formatProvider);
                }
                else if (o is decimal)
                {
                    result = ((decimal)o).ToString(formatName, formatProvider);
                }
                else if (o is int)
                {
                    result = ((int)o).ToString(formatName, formatProvider);
                }
                else if (o is bool)
                {
                    string[] split = formatName.Split(new char[] { ',' });
                    result = ((bool)o) ? split[0] : split[(split.Length > 1) ? 1 : 0];
                }
                else
                {
                    throw new ArgumentException("Unsupported format: " + formatName);
                }
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Failed to format {0} value \"{1}\" with the format \"{2}\".", o.GetType().Name, o, formatName), e);
            }
            return result;
        }

        public string ToString(object obj, string formatString, System.Globalization.CultureInfo culture)
        {
            return obj.ToString();
        }
    }

    public class FormatProvider : IFormatProvider
    {

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
}
