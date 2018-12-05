using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("TestResult")]
    public class TestResult
    {
        [Key, Column(Order =1)]
        public int LT { get; set; }

        [Key, Column(Order =2)]
        public int SequenceNo { get; set; }
        public int TestTypeID { get; set; }
        public bool IsActive { get; set; }
        public bool Passed { get; set; }
        public string QuantitativeResult { get; set; }
        public string QualitativeResult { get; set; }

    }
}