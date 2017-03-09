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

            var db1 = new SainiShopEntities1();
            var query = db1.SupplierMasters.Select(c => new SelectListItem
            {
                Value = c.SupplierId.ToString(),
                Text = c.SupplierName,

                //Selected = c.Product_id.Equals(3)
            }).ToList();

            var model = new PurchasemasterModal { supplierName = query.ToList() };
            return View(model);
        }

        [HttpPost]
        public ActionResult GetPurchaseHome(PurchasemasterModal request)
        {
            PurchaseDetail obj1 = new PurchaseDetail();// {Product_name=request.product_name, };
            obj1.SupplierName = request.SupplierName;
           // obj1.product_name = request.product_name;
            obj1.Quantity = request.Quantity;
            obj1.price = request.price;
           
            
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                objDb.PurchaseDetails.Add(obj1);
                //objDb.ProductMasters.Add(obj1);
                objDb.SaveChanges();
            }

            return View();

        }

        public ActionResult fillProductName(int supplierid)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var sup = (from supm in objDb.SupplierMasters
                       join prom in objDb.ProductMasters
                       on supm.SupplierId equals prom.Product_id
                       where supm.SupplierId == supplierid
                        select new
                        {
                            id = supm.SupplierId,
                           sup = prom.Product_name,
                            //description = prom.Description,
                            //price = prom.UnitperPrice
                        }).ToList();

            return Json(sup, JsonRequestBehavior.AllowGet);
        }

        //public Dictionary<int, string> ProductList()
        //{

        //    Dictionary<int, string> lista = new Dictionary<int, string>();
        //    using (SainiShopEntities1 objDb = new SainiShopEntities1())
        //    {
        //     var obj = (from k in objDb.ProductMasters select new { k.Product_id, k.Product_name}).ToList();// .ToList();

        //        foreach (var iteam in obj)
        //        {
        //            lista.Add(iteam.Product_id, iteam.Product_name);
        //        }
        //    }
        //    return lista;
        //}

    }
}