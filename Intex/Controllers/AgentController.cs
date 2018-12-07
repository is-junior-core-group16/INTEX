using Intex.DAL;
using Intex.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class AgentController : Controller
    {
        private IntexContext db = new IntexContext();


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CancelOrders()
        {
            var Id = User.Identity.GetUserId();

            if (Id == null)
            {
                ViewBag.ErrorMessage = "Please sign in before submitting an order.";
                return View("Error");
            }
            List<int> CID = db.Database.SqlQuery<List<int>>(
                "SELECT ClientID FROM Client WHERE SalesRep = " + "'" + Id + "'"
                ).FirstOrDefault();

            string CIDString = "(";
            foreach(int i in CID)
            {
                CIDString += i.ToString() + ", ";
            }
            CIDString += ")";

            IEnumerable<Compound> report = db.Database.SqlQuery<Compound>(
                "Select * FROM Compound WHERE (StatusID Between 1 AND 6) AND ClientID IN " + CIDString
                );
            foreach (Compound compound in report)
            {
                compound.Status = db.Statuses.Find(compound.StatusID);
            }
            return View(report);
        }

        public ActionResult Cancel(int LT)
        {
            db.Compounds.Find(LT).StatusID = 8;
            
            db.SaveChanges();
            Compound compy = db.Compounds.Find(LT);
            return View(compy);
        }
    }
}