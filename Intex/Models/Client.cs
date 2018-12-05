using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SalesRep { get; set; }
    }
}