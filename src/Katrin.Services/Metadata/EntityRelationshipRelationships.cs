
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
    
public partial class EntityRelationshipRelationships
{

	[DataMember]
    public System.Guid EntityRelationshipRelationshipsId { get; set; }

	[DataMember]
    public Nullable<System.Guid> EntityRelationshipId { get; set; }

	[DataMember]
    public System.Guid RelationshipId { get; set; }

	[DataMember]
    public byte[] VersionNumber { get; set; }



	[DataMember]
    public virtual EntityRelationship EntityRelationship { get; set; }

	[DataMember]
    public virtual Relationship Relationship { get; set; }

}

}