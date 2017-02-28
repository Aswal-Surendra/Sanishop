using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;
    using SaniShop.DAL;


namespace SaniShop.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetPurchaseHome()
        {


            return View();

        }
        [HttpPost]
        public ActionResult GetPurchaseHome(ProductModal request)
        {
            ProductMaster obj1 = new ProductMaster();// {Product_name=request.product_name, };
            obj1.Product_name = request.product_name;
            obj1.Description = request.description;
            obj1.UnitperPrice = request.unitperprice;
            using (SainiShopEntities objDb = new SainiShopEntities())
            {
                objDb.ProductMasters.Add(obj1);
                objDb.SaveChanges();
            }

            return View();

        }
    }
}