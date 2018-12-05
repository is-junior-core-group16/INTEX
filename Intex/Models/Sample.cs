using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Sample")]
    public class Sample
    {
      [Key, Column(Order =1)]
        public int LT { get; set; }
        [Key, Column(Order =2)]
        public int SequenceNo { get; set; }
        public float Quantity_mg { get; set; }
        public string Appearance { get; set; }
        public float ReportedWeight { get; set; }
        public float ActualWeight { get; set; }
        public int TestTypeID { get; set; }



    }
}