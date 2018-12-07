using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Models
{
    public class CreateWorkOrder
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] // IDK if this will work bc this model isn't added to a table
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Please enter the Compound name")]
        public string CompoundName { get; set; }

        public int LT { get; set; }
        [Required(ErrorMessage ="Please enter the Molecular Mass of the compound")]
        public float MolecularMass { get; set; }

        public string CustomerComments { get; set; }

        public bool IsExpedited { get; set; }

        public IList<string> SelectedTests { get; set; }
        [NotMapped]
        public IList<SelectListItem> AvailableTests { get; set; }

        public int ClientID { get; set; }

        public int StatusID { get; set; }


        public CreateWorkOrder()
        {
            SelectedTests = new List<string>();

          
            AvailableTests = new List<SelectListItem>();
        }

    }
}