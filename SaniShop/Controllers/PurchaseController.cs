using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;
using SaniShop.DAL;


namespace SaniShop.Controllers
{
    [Authorize]
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
        //        var db = new sainishopentities1();
        //        var query = db.productmasters.select(c => new selectlistitem
        //        {
        //            value = c.product_id.tostring(),
        //            text = c.product_name,
        //            selected = c.product_id.equals(3)
        //        }).tolist();

        //    var model = new PurchasemasterModal {Productname= query.ToList()};
            return View();
        }

        [HttpPost]
        public ActionResult GetPurchaseHome(PurchasemasterModal request)
        {
            PurchaseDetail obj1 = new PurchaseDetail();// {Product_name=request.product_name, };
            obj1.SupplierName = request.SupplierName;
            obj1.product_name = request.product_name;
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