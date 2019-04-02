using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.MetadataManager
{
    public class AttributeTypeItem
    {
        AttributeTypeEnum typeEnum;
        Guid typeID;
    }
    public enum AttributeTypeEnum
    {
        SingleLineText,
        OptionSet,
        Integer,
        Float,
        Decimal,
        Currency,
        MultipleLineText,
        DateTime,
        Lookup
    }
}
