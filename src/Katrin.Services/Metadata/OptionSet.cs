
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
    
public partial class OptionSet
{

    public OptionSet()
    {

        this.AttributePicklistValues = new HashSet<AttributePicklistValue>();

    }


	[DataMember]
    public System.Guid OptionSetId { get; set; }

	[DataMember]
    public string Name { get; set; }

	[DataMember]
    public bool IsCustomizable { get; set; }



	[DataMember]
    public virtual ICollection<AttributePicklistValue> AttributePicklistValues { get; set; }

}

}
