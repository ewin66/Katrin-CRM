
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
    
public partial class ImportMap
{

    public ImportMap()
    {

        this.ColumnMappings = new HashSet<ColumnMapping>();

    }


	[DataMember]
    public System.Guid ImportMapId { get; set; }

	[DataMember]
    public string Name { get; set; }

	[DataMember]
    public string Source { get; set; }



	[DataMember]
    public virtual ICollection<ColumnMapping> ColumnMappings { get; set; }

}

}
