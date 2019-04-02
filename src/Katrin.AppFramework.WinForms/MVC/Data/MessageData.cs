using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Data
{
    public enum MessageType
    {
        /// <summary>
        /// Error message
        /// </summary>
        ERROR_MESSAGE,

        /// <summary>
        /// Other message
        /// </summary>
        OTHER_MESSAGE
    }

    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Encapsulates errors messages
    /// <remarks>
    /// The class is marked as internal class, so that it's not accessible from a development project
    /// </remarks>
    /// </summary>
    internal class MessageData
    {
        #region Fields

        /// <summary>
        /// The error message
        /// </summary>
        string _errorMessage;

        /// <summary>
        /// Indicate wheter the message should be shown or not
        /// </summary>
        bool _lblContextMessageVisibility;

        /// <summary>
        /// The confirmation message
        /// </summary>
        string _otherMessage;

        #endregion Fields

        #region Public Properties

        /// <summary>
        /// <see cref="_errorMessage"/>
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                if (_errorMessage == null)
                {
                    if (_otherMessage == null) _lblContextMessageVisibility = false;
                    else _lblContextMessageVisibility = true;
                }
                else _lblContextMessageVisibility = true;
            }
        }

        /// <summary>
        /// <see cref="_lblContextMessageVisibility"/>
        /// </summary>
        public bool LblContextMessageVisibility
        {
            get { return _lblContextMessageVisibility; }
        }

        /// <summary>
        /// <see cref="_otherMessage"/>
        /// </summary>
        public string OtherMessage
        {
            get { return _otherMessage; }
            set
            {
                _otherMessage = value;
                if (_otherMessage == null)
                {
                    if (_errorMessage == null) _lblContextMessageVisibility = false;
                    else _lblContextMessageVisibility = true;
                }
                else _lblContextMessageVisibility = true;
            }
        }

        #endregion Public Properties
    }
}
