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
           
           
                IEnumerable<Backlog> currentOrders = db.Database.SqlQuery<Backlog>(
                    "SELECT" +
                    "   c.Name, wo.OrderID, co.CompoundName, co.LT, tt.TestDescription, wo.IsExpedited, wo.DateCreated, wo.DateArrived, co.StatusID " +
                    "FROM WorkOrder wo INNER JOIN Client c ON c.OrderID = wo.OrderID " +
                    "       INNER JOIN Compound co ON co.OrderID = wo.OrderID" +
                    "           INNER JOIN OrderTest ot ON ot.OrderID = wo.OrderID" +
                    "               INNER JOIN TestType tt ON tt.TestTypeID = ot.TestTypeID "
                    );


            return View(currentOrders); //Ad the status to this. 
        }

        public ActionResult Billing()
        {
            return View();
        }
    }
}