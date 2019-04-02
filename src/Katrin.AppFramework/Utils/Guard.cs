//===============================================================================
// Microsoft patterns & practices
// Smart Client Software Factory 2010
//===============================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================
//===============================================================================
// Microsoft patterns & practices
// CompositeUI Application Block
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Katrin.AppFramework.Utils
{
	/// <summary>
	/// Common guard clauses
	/// </summary>
	public static class Guard
	{
		/// <summary>
		/// Checks a string argument to ensure it isn't null or empty
		/// </summary>
		/// <param name="argumentValue">The argument value to check.</param>
		/// <param name="argumentName">The name of the argument.</param>
		public static void ArgumentNotNullOrEmptyString(string argumentValue, string argumentName)
		{
			ArgumentNotNull(argumentValue, argumentName);

            const string StringCannotBeEmpty = "The provided String argument {0} must not be empty.";
			if (argumentValue.Length == 0)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, StringCannotBeEmpty, argumentName));
		}

		/// <summary>
		/// Checks an argument to ensure it isn't null
		/// </summary>
		/// <param name="argumentValue">The argument value to check.</param>
		/// <param name="argumentName">The name of the argument.</param>
		public static void ArgumentNotNull(object argumentValue, string argumentName)
		{
			if (argumentValue == null)
				throw new ArgumentNullException(argumentName);
		}

		/// <summary>
		/// Checks an Enum argument to ensure that its value is defined by the specified Enum type.
		/// </summary>
		/// <param name="enumType">The Enum type the value should correspond to.</param>
		/// <param name="value">The value to check for.</param>
		/// <param name="argumentName">The name of the argument holding the value.</param>
        public static void EnumValueIsDefined(Type enumType, object value, string argumentName)
        {
            const string InvalidEnumValue = "The value of the argument {0} provided for the enumeration {1} is invalid.";

            if (Enum.IsDefined(enumType, value) == false)
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture,
                    InvalidEnumValue,
                    argumentName, enumType.ToString()));
        }

		/// <summary>
		/// Verifies that an argument type is assignable from the provided type (meaning
		/// interfaces are implemented, or classes exist in the base class hierarchy).
		/// </summary>
		/// <param name="assignee">The argument type.</param>
		/// <param name="providedType">The type it must be assignable from.</param>
		/// <param name="argumentName">The argument name.</param>
		public static void TypeIsAssignableFromType(Type assignee, Type providedType, string argumentName)
		{
            const string TypeNotCompatible = "The provided type {0} is not compatible with {1}.";
			if (!providedType.IsAssignableFrom(assignee))
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
					TypeNotCompatible, assignee, providedType), argumentName);
		}

        /// <summary>
        /// Verifies that an argument type is assignable from the provided type (meaning
        /// interfaces are implemented, or classes exist in the base class hierarchy).
        /// </summary>
        /// <param name="assignee">The argument type.</param>
        /// <param name="providedType">The type it must be assignable from.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void ObjectIsInstanceOfType(object assignee, Type providedType, string argumentName)
        {
            const string TypeNotCompatible = "The provided type {0} is not compatible with {1}.";
            if (!providedType.IsInstanceOfType(assignee))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    TypeNotCompatible, assignee, providedType), argumentName);
        }
	}
}
