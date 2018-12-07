using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class Report
    {
        [Key, Column(Order=1)]
        public string CompoundName { get; set; }
        public DateTime DateCreated { get; set; }
        public int LT { get; set; }

        [Key, Column(Order = 2)]
        public string TestDescription { get; set; }
        public bool Passed { get; set; }

    }
}