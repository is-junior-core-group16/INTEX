using Intex.DAL;
using Intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class SingaporeController : Controller
    {
        private IntexContext db = new IntexContext();
        // GET: Singaport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backlog()
        {

            var date = DateTime.Now;
            List<Backlog> backlog = db.Database.SqlQuery<Backlog>(
                "SELECT" +
                "  co.LT, c.Name, co.OrderID, co.CompoundName,  tt.TestDescription, wo.IsExpedited, wo.DateArrived, wo.DateCreated, wo.DateDue, co.StatusID " +
                "FROM WorkOrder wo INNER JOIN Client c ON c.ClientID = wo.ClientID " +
                "       INNER JOIN Compound co ON co.OrderID = wo.OrderID" +
                "           INNER JOIN OrderTest ot ON ot.OrderID = wo.OrderID" +
                "               INNER JOIN TestType tt ON tt.TestTypeID = ot.TestTypeID " +
                "WHERE co.StatusID = 2"
                ).ToList<Backlog>();
            return View(backlog);
        } //Make a way for them to change the status. Maybe in an HttpPost? A scheduled button?

        public ActionResult PendingArrival()
        {
            IEnumerable<Compoundlog> arrivers = db.Database.SqlQuery<Compoundlog>(
               "SELECT" +
             "  co.LT, c.Name, co.OrderID, co.CompoundName, wo.IsExpedited, wo.DateArrived, wo.DateCreated, (wo.DateCreated + 42) AS DateDue, co.StatusID " +
                "FROM WorkOrder wo INNER JOIN Client c ON c.ClientID = wo.ClientID " +
                "       INNER JOIN Compound co ON co.OrderID = wo.OrderID" +
                "           INNER JOIN OrderTest ot ON ot.OrderID = wo.OrderID" +
                "               INNER JOIN TestType tt ON tt.TestTypeID = ot.TestTypeID " +
               "WHERE co.StatusID = 1"
               );

            if(arrivers == null)
            {
                ViewBag.Thing = "Pending Arrivals";
                return View("empty");
            }

            return View(arrivers);
        }

        public ActionResult empty()
        {
            return View();
        }

        public ActionResult Arrived(int id)
        {
            
            db.Compounds.Find(id).StatusID = 2;
            db.SaveChanges();

            IEnumerable<Compoundlog> arrivers = db.Database.SqlQuery<Compoundlog>(
               "SELECT DISTINCT" +
             "  co.LT, c.Name, co.OrderID, co.CompoundName, wo.IsExpedited, wo.DateArrived, wo.DateCreated, (wo.DateCreated + 42) AS DateDue, co.StatusID " +
                "FROM WorkOrder wo INNER JOIN Client c ON c.ClientID = wo.ClientID " +
                "       INNER JOIN Compound co ON co.OrderID = wo.OrderID" +
                "           INNER JOIN OrderTest ot ON ot.OrderID = wo.OrderID" +
                "               INNER JOIN TestType tt ON tt.TestTypeID = ot.TestTypeID " +
               "WHERE co.StatusID = 1"
               );

            if (arrivers == null)
            {
                ViewBag.Thing = "Pending Arrivals";
                return View("empty");
            }
            return View("PendingArrival", arrivers);
        }
    }
}