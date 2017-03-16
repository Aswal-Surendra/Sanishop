using SaniShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;


namespace SaniShop.Controllers
{
    [CustomAuthorize("Admin")]
    public class SalesController : Controller
    {
        public SalesController()
        {
            Identity obj = new Identity();
            if (!obj.Identitys())
            {
                             
            }
        }

        // GET: Sales
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            var use = User.Identity.Name.ToString();
            var ause = User.Identity;

            var db1 = new SainiShopEntities1();
            var query = db1.ProductMasters.Select(c => new SelectListItem
            {
                Value = c.Product_id.ToString(),
                Text = c.Product_name,

                //Selected = c.Product_id.Equals(3)
            }).ToList();

            var model = new SalesDetailModel { Productname = query.ToList() };
            return View(model);
        }
        [HttpPost]
        public JsonResult Index(string Quantity, string Item, int Watts, string TotalAmo, string Desc, string Price , string Addcomments)
        {
            Sales_Details obj = new Sales_Details();
            obj.Description = Desc;
            obj.watt = Watts;
            obj.Product_name = Item;
            obj.Product_price = Price;
            obj.Quantity = Quantity;
            obj.Amount = TotalAmo;
            obj.sales_date = DateTime.Now.ToString();
            obj.AdditionalComments = Addcomments;
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                objDb.Sales_Details.Add(obj);
                objDb.SaveChanges();
            }
            var response = new Response(true, "Contact Successfully Submitted");
            return Json(response);            
        }

        public ActionResult FillWatt(int Productid)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var watt = (from prod in objDb.ProductMasters
                        join wat in objDb.WattMasters
                        on prod.Product_id equals wat.product_id
                        where prod.Product_id== Productid
                        select new
                        {
                            id = prod.Product_id,
                            watt = wat.watt,
                            description = prod.Description,
                            price = prod.UnitperPrice
                        }).ToList();

            return Json(watt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TotalAmount(string Unitprice, string Quantity, int  Productid)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var margin = objDb.ProductMasters.Where(z => z.Product_id == Productid).Select(x => x.marginPerUnit).FirstOrDefault();
            var response = TotalPrice(Unitprice, Quantity, margin);
            return Json(response);
        }


        public decimal TotalPrice(string Unitprice, string Quantity, int? margin)
        {
            var amount = Convert.ToInt32(Unitprice) * Convert.ToInt32(Quantity) ;
            var totalprice = (amount * margin / 100) + amount;
            return Convert.ToDecimal(totalprice);
        }

        public ActionResult SalesTable()
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var records = objDb.Sales_Details;
            return View(records);

        }
    }
}