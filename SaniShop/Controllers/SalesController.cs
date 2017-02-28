using SaniShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;


namespace SaniShop.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(SalesDetailModel request)
        {
            SalesDetails obj = new SalesDetails();
            obj.id = request.id;
            obj.Product_id = request.Product_id;
            obj.Product_price = request.Product_price;
            obj.Quantity = request.Quantity;
            obj.salesdate = DateTime.Now.ToString();
            using (SainiShopEntities objDb = new SainiShopEntities())
            {
                objDb.SalesDetails.Add(obj);
                objDb.SaveChanges();
            }
            return View();
        }
    }
}