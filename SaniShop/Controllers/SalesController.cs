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

            var db1 = new SainiShopEntities1();
            var query = db1.ProductMasters.Select(c => new SelectListItem
            {
                Value = c.Product_id.ToString(),
                Text = c.Product_name,
                Selected = c.Product_id.Equals(3)
            }).ToList();

            var model = new SalesDetailModel { Productname = query.ToList() };
            return View(model);
        }

        //[HttpGet]
        //public ActionResult GetPurchaseHome()
        //{
        //    var db = new SainiShopEntities1();
        //    var query = db.ProductMasters.Select(c => new SelectListItem
        //    {
        //        Value = c.Product_id.ToString(),
        //        Text = c.Product_name,
        //        Selected = c.Product_id.Equals(3)
        //    }).ToList();

        //    var model = new ProductModal { Productname = query.ToList() };
        //    return View(model);
        //}

        [HttpPost]
        public ActionResult Index(SalesDetailModel request)
        {
            SalesDetail obj = new SalesDetail();
            obj.id = request.id;
            obj.Product_id = request.Product_id;
            obj.Product_price = request.Product_price;
            obj.Quantity = request.Quantity;
            obj.salesdate = DateTime.Now.ToString();
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                objDb.SalesDetails.Add(obj);
                objDb.SaveChanges();
            }
            return View();
        }
    }
}