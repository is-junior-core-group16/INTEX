using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }

    }
}