using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        public float QuantityinStore { get; set; }
        public string Description { get; set; }

    }
}