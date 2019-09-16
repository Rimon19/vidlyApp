using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.EntryModel
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer field is required !")]
        [StringLength(255)]
        public string CustomerName { get; set; }
       
        public bool IsSubscribeNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Display(Name = "Membership Type")]
        [Required]
        public byte MemberShipTypeId { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}