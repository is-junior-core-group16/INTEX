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
        [Key, Column(Order =1)]
        public int MaterialId { get; set; }
        [Key, Column(Order = 2)]
        public int TestTypeID { get; set; }
        public float QuantityNeeded { get; set; }
        public float CostOfMaterial { get; set; }

    }
}