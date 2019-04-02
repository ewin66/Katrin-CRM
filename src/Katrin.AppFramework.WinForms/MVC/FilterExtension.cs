using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// This class contains custom extensions
    /// </summary>
    public static class FilterExtension
    {
        #region Public Methods

        /// <summary>
        /// Gets the list of custom attributes for a specific type
        /// </summary>
        /// <typeparam name="TFilter">The type of the custom attributes</typeparam>
        /// <param name="methodInfo">The extended class</param>
        /// <returns>The list of custom filters</returns>
        public static IList<TFilter> GetCustomAttributes<TFilter>(this MethodInfo methodInfo)
        {
            //Retrieve the list of attributes
            Object[] filtersAttribute = methodInfo.GetCustomAttributes(typeof(TFilter), false);
            if (filtersAttribute == null || filtersAttribute.Length == 0) return null;

            //Creating the list
            List<TFilter> listOfTFilter = new List<TFilter>();
            foreach (TFilter filter in filtersAttribute)
            {
                listOfTFilter.Add(filter);
            }

            return listOfTFilter;
        }

        /// <summary>
        /// Retrives all filters of an action
        /// </summary>
        /// <param name="action">The action</param>
        /// <returns>The list of all filters</returns>
        public static FilterInfo GetFilters(this MethodInfo action)
        {
            FilterInfo filterInfo = new FilterInfo();

            //Retrieve Authorization list
            filterInfo.AuthorizationFilters = action.GetCustomAttributes<IAuthorizationFilter>();

            //Retrive ActionFilter list
            filterInfo.ActionFilters = action.GetCustomAttributes<IActionFilter>();

            //Retrieving the ResultFilter list
            filterInfo.ResultFilters = action.GetCustomAttributes<IResultFilter>();

            //Retrieve ExceptionFilter list
            filterInfo.ExceptionFilters = action.GetCustomAttributes<IExceptionFilter>();

            //return the filter info
            return filterInfo;
        }

        #endregion Public Methods
    }
}
