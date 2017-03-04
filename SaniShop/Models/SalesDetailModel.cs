using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.DAL;

namespace SaniShop.Models
{
    public class SalesDetailModel
    {

        public int id { get; set; }
        public string Sales_id { get; set; }
        public string Product_id { get; set; }
        public string Quantity { get; set; }
        public string Product_price { get; set; }
        public string SubTotal { get; set; }
        public string salesdate { get; set; }
        public List<SelectListItem> Productname { get; set; }
    }
}