using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.DAL;

namespace SaniShop.Models
{
    public class ProductmasterModal
    {
        public int id { get; set; }
       public string purchase_id  { get; set; }
        public string product_name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string PurchaseDate { get; set; }
        public decimal price { get; set; }
        public string additionalComment { get; set; }
        public string SupplierName { get; set; }
        public List<SelectListItem> Productname { get; set; }
    }
}