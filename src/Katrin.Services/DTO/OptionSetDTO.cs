using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katrin.Services.DTO
{
    public class OptionDTO
    {
        public System.Guid OptionId { get; set; }
        public string DisplayName { get; set; }
        public int? Value { get; set; }
        public int? DisplayOrder { get; set; }
        public string Description { get; set; }
    }
    public class OptionSetDTO
    {
        public System.Guid OptionSetId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsCustomizable { get; set; }
        public List<OptionDTO> OptionList { get; set; }
    }
}
