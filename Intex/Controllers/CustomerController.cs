using Intex.DAL;
using Intex.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class CustomerController : Controller
    {

        private IntexContext db = new IntexContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateWorkOrder()
        {
            var model = new CreateWorkOrder
            {
                AvailableTests = GetTests()
            };

            return View(model);
        }

        public ActionResult PastOrders()
        {
            var Id = User.Identity.GetUserId();

            if (Id == null)
            {
                ViewBag.ErrorMessage = "Please sign in before submitting an order.";
                return View("Error");
            }

            int CID = db.Database.SqlQuery<int>(
                "SELECT ClientID FROM ClientEmployee WHERE ID = " + "'" + Id + "'"
                ).FirstOrDefault();

            
            IEnumerable<Report> pastlist = db.Database.SqlQuery<Report>(
                
                "SELECT" +
                "c.CompoundName, wo.DateCreated, c.LT, tt.TestDescription, tr.Passed " +
                
                "FROM WorkOrder wo " +
                "       INNER JOIN Compound c ON c.OrderID = wo.OrderID" +
                "           INNER JOIN OrderTest ot ON ot.OrderID = wo.OrderID" +
                "               INNER JOIN TestType tt ON tt.TestTypeID = ot.TestTypeID " +
                "                   INNER JOIN TestResult tr ON tr.LT = c.LT AND tr.TestTypeID = tt.TestTypeID " +
                "WHERE c.ClientID = " + CID +
                " AND c.StatusID = 7"
                );
                
           if(pastlist == null)
            {
                return View("empty");
            }
            
            return View(pastlist);
        }

        

        public ActionResult CurrentOrders()
        {
            var Id = User.Identity.GetUserId();

            if (Id == null)
            {
                ViewBag.ErrorMessage = "Please sign in before submitting an order.";
                return View("Error");
            }

            int CID = db.Database.SqlQuery<int>(
                "SELECT ClientID FROM ClientEmployee WHERE ID = " + "'" + Id + "'"
                ).FirstOrDefault();

            List<Compound> report = db.Database.SqlQuery<Compound>(
                "Select * FROM Compound WHERE (StatusID Between 1 AND 6) AND ClientID = " + CID
                ).ToList<Compound>();
            
            foreach (Compound compound in report)
            {
                compound.Status = db.Statuses.Find(compound.StatusID);
            }
            return View(report);
        }

        [HttpPost]
        public ActionResult CreateWorkOrder(CreateWorkOrder order)
        {
            
           if(ModelState.IsValid)
            {
                Compound compound = new Compound();
                string Id = User.Identity.GetUserId();

                if (Id == null)
                {
                    ViewBag.ErrorMessage = "Please sign in before submitting an order.";
                    return View("Error");
                }
                else if(order.SelectedTests.Count == 0)
                {
                    ViewBag.ErrorMessage = "Please select a test to perform";
                    return View("Error");
                }

                int LT = db.Database.SqlQuery<int>(
                    "SELECT MAX(LT) + 1 FROM Compound").FirstOrDefault();
                order.LT = LT; 
                order.StatusID = 1;
                int OrderID = db.Database.SqlQuery<int>(
                    "SELECT MAX(OrderID) + 1 FROM WorkOrder").FirstOrDefault();
                order.OrderID = OrderID;
             
              
                int ClientID = db.Database.SqlQuery<int>(
                    "SELECT ClientID FROM ClientEmployee WHERE Id = '" + Id + "'").FirstOrDefault();
                order.ClientID = ClientID;

                DateTime date = DateTime.Now;

                db.Database.ExecuteSqlCommand(
                    "INSERT INTO WorkOrder (OrderID, ClientID, CustomerComments, IsExpedited, DateCreated) " +
                    "VALUES (" + order.OrderID + ", " + order.ClientID + ", '" + order.CustomerComments + "', " +
                    Convert.ToInt16(order.IsExpedited) + ", '" + date + "')"
                    );

                db.Database.ExecuteSqlCommand(
                    "INSERT INTO Compound (LT, OrderID, ClientID, CompoundName, MolecularMass, StatusID, InvoiceID) " +
                    "VALUES (" + order.LT + ", " + order.OrderID + ", " + order.ClientID + ", '" + order.CompoundName + "', " +
                    order.MolecularMass + ", 1, null)"
                    ); 
                /*Compound pound = new Compound();
                pound.LT = LT;
                pound.OrderID = OrderID;
                pound.CompoundName = order.CompoundName;
                pound.MolecularMass = order.MolecularMass;
                pound.StatusID = 1;
                db.Compounds.Add(pound);*/

                foreach(string i in order.SelectedTests)
                {
                    OrderTest ot = new OrderTest();
                    ot.OrderID = order.OrderID;
                    ot.TestTypeID = Convert.ToInt32(i);
                    db.OrderTests.Add(ot);
                }
                db.SaveChanges();



                return View("ThankYou");
            }
            return View(order);
        }


        public ActionResult ThankYou()
        {
            return View();
        }

        private IList<SelectListItem> GetTests()
        {
            return new List<SelectListItem>
        {
            new SelectListItem {Text = "BioChemical Pharmacology", Value = "2"},
            new SelectListItem {Text = "DiscoveryScreen", Value = "3"},
            new SelectListItem {Text = "ImmunoScreen", Value = "4"},
            new SelectListItem {Text = "ProfilingScreen", Value = "5"},
            new SelectListItem {Text = "PharmaScreen", Value = "6"},
            new SelectListItem {Text = "CustomScreen", Value = "7"},
            new SelectListItem {Text = "Other (Please specify in the comments section)", Value = "8"},
        };
        }

        public ActionResult Calendar()
        {
            return View();
        }
    }
}