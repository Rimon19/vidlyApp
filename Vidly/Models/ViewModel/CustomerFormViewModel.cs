using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models.EntryModel;

namespace Vidly.Models.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}