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
            Sales_Details obj = new Sales_Details();
            obj.Description = request.Description;
            foreach(var item in request.wattmain)
            {
                obj.watt = Convert.ToInt32(item.Text);// .wattid;
            }
            obj.Product_name = request.Product_id;
            obj.Product_price = request.Product_price;
            obj.Quantity = request.Quantity;
            obj.sales_date = DateTime.Now.ToString();
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                objDb.Sales_Details.Add(obj);
                objDb.SaveChanges();
            }
            return View();
        }

        public ActionResult FillWatt(int State)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var watt = (from prod in objDb.ProductMasters
                        join wat in objDb.WattMasters
                        on prod.Product_id equals wat.product_id
                        where prod.Product_id==State
                        select new
                        {
                            id = prod.Product_id,
                            watt = wat.watt
                        }).ToList();

            return Json(watt, JsonRequestBehavior.AllowGet);
        }


    }
}