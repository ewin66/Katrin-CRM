
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Katrin.Services.Metadata
{

using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
public partial class AttributeLookupValue
{

	[DataMember]
    public System.Guid AttributeLookupValueId { get; set; }

	[DataMember]
    public System.Guid AttributeId { get; set; }

	[DataMember]
    public System.Guid EntityId { get; set; }

	[DataMember]
    public Nullable<System.Guid> DisplayEntityAttributeId { get; set; }

	[DataMember]
    public byte[] VersionNumber { get; set; }



	[DataMember]
    public virtual Entity Entity { get; set; }

}

}
