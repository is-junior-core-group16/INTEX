using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("ClientEmployee")]
    public class ClientEmployee
    {
        [Key]
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; } //Is this a foreign key?
    }
}