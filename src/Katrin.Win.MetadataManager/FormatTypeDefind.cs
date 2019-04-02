using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.MetadataManager
{
    public class FormatTypeItem
    {
        Guid _formatId;
        string _formatName;
        Guid _formatParentId;
        Guid _attributeTypeId;

        public Guid FormatId
        {
            get { return _formatId; }
            set { _formatId = value; }
        }
        public string FormatName
        {
            get { return _formatName; }
            set { _formatName = value; }
        }
        public Guid FormatParentId
        {
            get { return _formatParentId; }
            set { _formatParentId = value; }
        }
    }
    public class FormatTypeDefind
    {
        public FormatTypeDefind()
        {

        }
        private FormatTypeItem Item(string formatId, string formatName, string formatParentId)
        {
            return new FormatTypeItem { FormatId = Guid.Parse(formatId), FormatName = formatName,
                FormatParentId = Guid.Parse(formatParentId) };
        }
        public List<FormatTypeItem> GetFormatList()
        {
            List<FormatTypeItem> formatList = new List<FormatTypeItem>(
                new FormatTypeItem[]{
                    Item("00000000-0000-0000-00bb-110000000001","SingleLineText","00000000-0000-0000-00aa-11000000001e"),
                    Item("00000000-0000-0000-00bb-110000000002","OptionSet","00000000-0000-0000-00aa-110000000030"),
                    Item("00000000-0000-0000-00bb-110000000003","Integer","00000000-0000-0000-00aa-110000000019"),
                    Item("00000000-0000-0000-00bb-110000000004","Float","00000000-0000-0000-00aa-110000000017"),
                    Item("00000000-0000-0000-00bb-110000000005","Decimal","00000000-0000-0000-00aa-110000000016"),
                    Item("00000000-0000-0000-00bb-110000000006","Currency","00000000-0000-0000-00aa-11000000001a"),
                    Item("00000000-0000-0000-00bb-110000000007","MultipleLineText","00000000-0000-0000-00aa-11000000001e"),
                    Item("00000000-0000-0000-00bb-110000000008","DateTime","00000000-0000-0000-00aa-110000000015"),
                    Item("00000000-0000-0000-00bb-110000000009","Lookup","00000000-0000-0000-00aa-110000000031"),
                    Item("00000000-0000-0000-00cc-110000000001","E-mail","00000000-0000-0000-00bb-110000000001"),
                    Item("00000000-0000-0000-00cc-110000000002","Text","00000000-0000-0000-00bb-110000000001"),
                    Item("00000000-0000-0000-00cc-110000000003","Text Area","00000000-0000-0000-00bb-110000000001"),
                    Item("00000000-0000-0000-00cc-110000000004","URL","00000000-0000-0000-00bb-110000000001"),
                    Item("00000000-0000-0000-00cc-110000000005","Ticker Symbol","00000000-0000-0000-00bb-110000000001"),
                    Item("00000000-0000-0000-00cc-110000000006","Pricing Decimal Precision","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000007","Currency Precision","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000008","0","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000009","1","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000010","2","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000011","3","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000012","4","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000013","5","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000014","6","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000015","7","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000016","8","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000017","9","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000018","10","00000000-0000-0000-00bb-110000000006"),
                    Item("00000000-0000-0000-00cc-110000000019","Date Only","00000000-0000-0000-00bb-110000000008"),
                    Item("00000000-0000-0000-00cc-110000000020","Date and Time","00000000-0000-0000-00bb-110000000008")
                }
                );
            return formatList;
        }
    }
}
