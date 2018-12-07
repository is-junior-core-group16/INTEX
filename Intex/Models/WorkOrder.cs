using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
        public int OrderID { get; set; }
        public string ClientID { get; set; }
        public DateTime DateArrived { get; set; }
        public int ReceivedBy { get; set; }
        public DateTime DateDue { get; set; }
        public string CustomerComments { get; set; }
        public string EmployeeComments { get; set; }
        public bool Discount { get; set; }
        public bool IsExpedited { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}