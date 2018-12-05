using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("TestType")]
    public class TestType
    {
        [Key]
        public int TestTypeID { get; set; }
        public float HourlyRate { get; set; }
        public float TotalMaterialCost { get; set; }
        public string TestDescription { get; set; }
        public float HoursRequired { get; set; }
        public bool IsSecondary { get; set; }
        public string TestInstructions { get; set; }

    }
}