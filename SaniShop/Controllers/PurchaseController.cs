﻿using System;
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
    }
}