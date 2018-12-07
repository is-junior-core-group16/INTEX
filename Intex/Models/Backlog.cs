using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class Backlog
    {
        [Key]
        public int LT { get; set; }

        public string Name { get; set; }
        public int OrderID { get; set; }
        public string CompoundName { get; set; }
        public string TestDescription { get; set; }
        public bool IsExpedited { get; set; }
        public DateTime? DateArrived { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateDue { get; set; }
        public int? StatusID { get; set; }

    }
}