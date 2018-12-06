using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("OrderTest")]
    public class OrderTest
    {
        [Key, Column(Order=1)]
        public int OrderID { get; set; }

        [Key, Column(Order =2)]
        public int TestTypeID { get; set; }


    }
}