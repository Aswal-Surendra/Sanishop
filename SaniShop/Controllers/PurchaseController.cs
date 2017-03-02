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
                var db = new SainiShopEntities1();
                var query = db.ProductMasters.Select(c => new SelectListItem
                {
                    Value = c.Product_id.ToString(),
                    Text = c.Product_name,
                    Selected = c.Product_id.Equals(3)
                }).ToList();

            var model = new ProductModal {Productname= query.ToList()};
            return View(model);
        }



        [HttpPost]
        public ActionResult GetPurchaseHome(ProductModal request)
        {
            ProductMaster obj1 = new ProductMaster();// {Product_name=request.product_name, };
            obj1.Product_name = request.product_name;
            obj1.Description = request.description;
            obj1.UnitperPrice = request.unitperprice;
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                objDb.ProductMasters.Add(obj1);
                objDb.SaveChanges();
            }

            return View();

        }

        public Dictionary<int, string> ProductList()
        {

            Dictionary<int, string> lista = new Dictionary<int, string>();
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
             var obj = (from k in objDb.ProductMasters select new { k.Product_id, k.Product_name}).ToList();// .ToList();

                foreach (var iteam in obj)
                {
                    lista.Add(iteam.Product_id, iteam.Product_name);
                }
            }
            return lista;
        }

    }
}