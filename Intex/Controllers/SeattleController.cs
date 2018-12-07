using Intex.DAL;
using Intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class SeattleController : Controller
    {
        // GET: Seattle

        private IntexContext db = new IntexContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CurrentOrders()
        {


            List<Backlog> currentorders = db.Database.SqlQuery<Backlog>(
             "SELECT" +
             "  co.LT, c.Name, co.OrderID, co.CompoundName,  tt.TestDescription, wo.IsExpedited, wo.DateArrived, wo.DateCreated, wo.DateDue, co.StatusID " +
             "FROM WorkOrder wo INNER JOIN Client c ON c.ClientID = wo.ClientID " +
             "       INNER JOIN Compound co ON co.OrderID = wo.OrderID" +
             "           INNER JOIN OrderTest ot ON ot.OrderID = wo.OrderID" +
             "               INNER JOIN TestType tt ON tt.TestTypeID = ot.TestTypeID " +
             "WHERE co.StatusID Between 2 AND 6"
             ).ToList<Backlog>();


            return View(currentorders); //Ad the status to this. 
        }

        public ActionResult Billing()
        {
            return View();
        }
    }
}