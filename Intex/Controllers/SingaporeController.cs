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
            IEnumerable<Backlog> backlog = db.Database.SqlQuery<Backlog>(
                "SELECT" +
                "   c.Name, wo.OrderID, co.CompoundName, co.LT, tt.TestDescription, wo.IsExpedited, wo.DateArrived, wo.DateDue " +
                "FROM WorkOrder wo INNER JOIN Client c ON c.OrderID = wo.OrderID " +
                "       INNER JOIN Compound co ON co.OrderID = wo.OrderID" +
                "           INNER JOIN OrderTest ot ON ot.OrderID = wo.OrderID" +
                "               INNER JOIN TestType tt ON tt.TestTypeID = ot.TestTypeID " +
                "WHERE co.StatusID = 2"
                );
            return View(backlog);
        }
    }
}