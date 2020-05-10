using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chargosh.Models;

namespace Chargosh.Controllers
{
    public class SortController : Controller
    {
        ChargoshContext db =new ChargoshContext();
        // GET: Sort
        public ActionResult SortByCategory(int id)
        {
            ViewBag.id = id;
            return View(db.Products.ToList());
        }
    }
}