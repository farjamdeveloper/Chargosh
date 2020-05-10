using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chargosh.Models;

namespace Chargosh.Controllers
{
    public class PaymentController : Controller
    {
        ChargoshContext db=new ChargoshContext();
        // GET: Payment
        public ActionResult Index(int id)
        {
            var q = from m in db.Products where m.ProductId == id select new { m.Price, m.Description };
            foreach (var item in q)
            {


                System.Net.ServicePointManager.Expect100Continue = false;
                zarinpal.PaymentGatewayImplementationService zp = new zarinpal.PaymentGatewayImplementationService();
                string Authority;
                int status = zp.PaymentRequest("4de9b0e6-5e35-11e7-8b84-000c295eb8fc", (int)item.Price,
                    item.Description, "farjamdeveloper@gmail.com", "09215506570", "http://www.chargosh.com/Payment/Verify",
                    out Authority);
                if (status == 100)
                {
                    Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
                }
                else
                {
                    Response.Write("error: " + status);
                }
            }
            return View();
        }
        public ActionResult CallBack(string Status, string Authority)
        {
            if (Status == "OK")
            {
                int Amount = 100;
                long RefID;
                System.Net.ServicePointManager.Expect100Continue = false;
                zarinpal.PaymentGatewayImplementationService zp = new zarinpal.PaymentGatewayImplementationService();

                int sVerification = zp.PaymentVerification("4de9b0e6-5e35-11e7-8b84-000c295eb8fc", Authority, Amount, out RefID);
            }
            
            return View("ActionResult");
        }

        public ActionResult Verify(string Status, string Authority)
        {
            if (Status == "OK")
            {
                int Amount = 100;
                long RefID;
                System.Net.ServicePointManager.Expect100Continue = false;
                zarinpal.PaymentGatewayImplementationService zp = new zarinpal.PaymentGatewayImplementationService();

                int sVerification = zp.PaymentVerification("4de9b0e6-5e35-11e7-8b84-000c295eb8fc", Authority, Amount, out RefID);
            }

            return View("ActionResult");
        }



        //[HttpPost]
        //public ActionResult Index(string test)
        //{
        //    //var q = from m in db.Products where m.ProductId == id select new {m.Price, m.Description};
        //    //foreach (var item in q)
        //    //{


        //    //System.Net.ServicePointManager.Expect100Continue = false;
        //    //zarinpal.PaymentGatewayImplementationService zp = new zarinpal.PaymentGatewayImplementationService();
        //    //string Authority;
        //    //int status = zp.PaymentRequest("4de9b0e6-5e35-11e7-8b84-000c295eb8fc", (int)item.Price,
        //    //   "صنایع دستی چارگوش", "farjamdeveloper@gmail.com", "09215506570", "http://www.chargosh.com/Payment/Verify",
        //    //    out Authority);
        //    //if (status == 100)
        //    //{
        //    //    Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
        //    //}
        //    //else
        //    //{
        //    //    Response.Write("error: " + status);
        //    //}
        //    //}
        //    //return View();
        //}

    }
}