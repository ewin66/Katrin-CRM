
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
    
public partial class LocalizedLabel
{

	[DataMember]
    public System.Guid LocalizedLabelId { get; set; }

	[DataMember]
    public int LanguageId { get; set; }

	[DataMember]
    public System.Guid ObjectId { get; set; }

	[DataMember]
    public string ObjectColumnName { get; set; }

	[DataMember]
    public string Label { get; set; }

	[DataMember]
    public byte[] VersionNumber { get; set; }

}

}
