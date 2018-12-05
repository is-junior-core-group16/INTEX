using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("TestMaterial")]
    public class TestMaterial
    {
        [Key]
        public int TestTypeID { get; set; }
        public int MaterialId { get; set; }
        public float QuantityNeeded { get; set; }
        public float CostOfMaterial { get; set; }

    }
}