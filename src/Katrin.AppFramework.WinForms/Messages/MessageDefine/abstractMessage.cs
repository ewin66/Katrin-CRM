using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages.MessageDefine;


namespace Katrin.AppFramework.WinForms.Messages
{
    /// <summary>
    /// MessageBase
    /// message must base this object
    /// date:2012-11-15
    /// </summary>
    public abstract class AbstractMessage
    {
       protected MsgAppTypes _appType;
       protected MsgDomainTypes _domainType;
       protected Guid _workspceId;
       protected string _objectName;
       protected string _objectID;

       public AbstractMessage()
       {
           this._appType = MsgAppTypes.App;
           this._domainType = MsgDomainTypes.Domain;
       }

  
       public MsgAppTypes AppType
       {
           get { return _appType; }
           set { _appType = value; }
       }

       public MsgDomainTypes DomainType
       {
           get{return _domainType;}
           set { _domainType = value; }
       }

       public Guid WorkSpaceID
       {
           get{return _workspceId;}
           set{_workspceId = value;}
       }

       public string ObjectName
       {
           get{return _objectName;}
           set{_objectName = value;}
       }

       public string OjbectID
       {
           get{return _objectID;}
           set {_objectID = value; }
       }

    }
}
