using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class Quote
    {
        [Key]
        public int QuoteID { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Comments { get; set; }
    }
}