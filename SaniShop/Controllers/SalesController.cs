using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaniShop.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            var i = 1;
            return View();
        }

        public ActionResult GetResult()
        {

            return View();
        }
    }
}