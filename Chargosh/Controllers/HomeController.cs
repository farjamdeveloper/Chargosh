using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chargosh.Models;

namespace Chargosh.Controllers
{
    
    public class HomeController : Controller
    {
        ChargoshContext db=new ChargoshContext();
        public ActionResult Index()
        {
           
            return View("PartialView/_Product", db.Products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            //ViewBag.Product=new SelectList(db.Products,"مرتب سازی","ProductName",product.Price);
            return View( db.Products.ToList());
           
        }

        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i=>i.ProductId==id).ToList());
        }

        public ActionResult Showcomment(int id)
        {
            return PartialView(db.Comments.Where(i=>i.ProductId==id).ToList());
        }


        public ActionResult InsertComment()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult InsertComment(Comment comment, int id)
        {
            comment.ProductId = id;
            db.Comments.Add(comment);
            db.SaveChanges();
            return PartialView("Showcomment", db.Comments.Where(i=>i.ProductId==id).ToList());
        }

        public ActionResult SearchProduct(string search)
        {
            var product = db.Products.Where(s => s.Tag.Contains(search)|| s.ProductName.Contains(search) || s.Description.Contains(search));
            return View("Product",product.ToList());
        }

        public ActionResult Drop()
        {
            

            return View("Product");
        }
        [HttpPost]
        public ActionResult Drop(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            //ViewBag.test = id;
            return View();
        }
    }
}