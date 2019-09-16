using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.EntryModel
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public String Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

    }
}