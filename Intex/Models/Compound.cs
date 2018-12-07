using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Compound")]
    public class Compound
    {
        [Key]
        public int LT { get; set; }
        public int OrderID { get; set; }
        public string CompoundName { get; set; }
        public double MolecularMass { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public int? InvoiceID { get; set; }

        public int StatusID { get; set; }
        public virtual Status Status { get; set; }
    }
}