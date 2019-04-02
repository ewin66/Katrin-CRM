using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Data
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Contains session datas
    /// </summary>
    public class Session
    {
        #region Fields

        /// <summary>
        /// <see cref="MessageData" />
        /// </summary>
        private MessageData _messageData;

        /// <summary>
        /// Set of session datas;
        /// </summary>
        private IDictionary<string, AbstractBaseData> _sessionData;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructeur
        /// </summary>
        public Session()
        {
            if (this._messageData == null)
            {
                this._messageData = new MessageData();
            }
        }

        #endregion Constructors

        #region Internal Properties

        /// <summary>
        ///  <see cref="MessageData" />
        /// </summary>
        internal MessageData MessageData
        {
            get { return _messageData; }
        }

        #endregion Internal Properties

        #region Public Properties

        /// <summary>
        /// Set of session data
        /// </summary>
        public IDictionary<string, AbstractBaseData> SessionData
        {
            get { return _sessionData; }
            set { _sessionData = value; }
        }

        #endregion Public Properties

        #region Public Methods
        /// <summary>
        /// Adding error message or confirmation message
        /// </summary>
        /// <param name="message">The message to add</param>
        /// <param name="messageType">The message type</param>
        public void AddMessage(string message, MessageType messageType)
        {
            if (messageType == MessageType.ERROR_MESSAGE) this.MessageData.ErrorMessage = message;
            if (messageType == MessageType.OTHER_MESSAGE) this.MessageData.OtherMessage = message;
        }

        /// <summary>
        /// Clear all messages
        /// </summary>
        public void ClearErrorsAndMessage()
        {
            this.MessageData.ErrorMessage = this.MessageData.OtherMessage = null;
        }

        /// <summary>
        /// Gets a particular message from his type
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public string GetMessage(MessageType messageType)
        {
            if (messageType == MessageType.ERROR_MESSAGE) return this.MessageData.ErrorMessage;
            if (messageType == MessageType.OTHER_MESSAGE) return this.MessageData.OtherMessage;
            return null;
        }
        #endregion Public Methods

        public AbstractBaseData this[string key]
        {
            get
            {
                if (this._sessionData.ContainsKey(key))
                    return this._sessionData[key];
                var keyMissingException = "The key {0} doesn't exist";
                keyMissingException = ResourceService.GetString("KeyMissingException");
                //KeyMissingException: The key {0} doesn't exist
                LoggingService.ErrorFormatted(keyMissingException, key);
                throw new ArgumentException(String.Format(keyMissingException, key));
            }
        }
    }
}
