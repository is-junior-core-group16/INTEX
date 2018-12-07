using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public int LT { get; set; }
        public int ClientID { get; set; }
        public DateTime PaymentDateDue { get; set; }
        public DateTime EarlyPaymentDue { get; set; }
        public float DiscountPercent { get; set; }
        public string DiscountNotes { get; set; }
        public float AmountPaid { get; set; }
        public float AmountCharged { get; set; }
        public float MaterialsCost { get; set; }
        public float Hourscost { get; set; }
    }
}