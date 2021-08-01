using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheIdealProject_Web_MVC.Controllers
{
    public class Tm_ProductController : BaseController
    {
        public ActionResult Index()
        {
            var list = DB.Tm_Product.Where(p => p.TmProductPk > 1).ToList();
            return View(list);
        }
    }
}