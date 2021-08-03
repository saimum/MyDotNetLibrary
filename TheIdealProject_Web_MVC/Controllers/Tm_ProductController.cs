using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheIdealProject_Web_MVC.Models;
using TheIdealProject_Web_MVC.ProjectUtilities;

namespace TheIdealProject_Web_MVC.Controllers
{
    public class Tm_ProductController : BaseController
    {
        
        public ActionResult Index()
        {
            var list = DB.Tm_Product.Where(p => p.TmProductPk > 1).ToList();
            return View(list);
        }
        #region Create
        [LoginAuthorizer]
        public ActionResult Create()
        {
            ViewBag.product_TmCategoryFk = new SelectList(DB.Tm_Category, "TmCategoryPk", "CategoryName");
            ViewBag.product_TmUserFk_Creator = new SelectList(DB.Tm_User, "TmUserPk", "UserName");
            ViewBag.product_TmUserFk_Modifier = new SelectList(DB.Tm_User, "TmUserPk", "UserName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tm_Product model)
        {
            //Check
            return View(model);
        }
        #endregion
    }
}