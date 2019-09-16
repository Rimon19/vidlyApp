using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.EntryModel;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer field is required !")]
        [StringLength(255)]
        public string CustomerName { get; set; }

        public bool IsSubscribeNewsLetter { get; set; }
        
        [Required]
        public byte MemberShipTypeId { get; set; }
        
        public DateTime? BirthDate { get; set; }
    }
}