using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheIdealProject_Web_MVC.Models;
using TheIdealProject_Web_MVC.ProjectUtilities;

namespace TheIdealProject_Web_MVC.Controllers
{
    public class AccessController : Controller
    {
        DB_TheIdealPrtojectEntities DB = new DB_TheIdealPrtojectEntities();
        public ActionResult Index()
        {
            return View(DB.Tm_User.Where(a => a.TmUserPk > 1).ToList());
        }
        public ActionResult Login(long Id)
        {
            var CurrentUser = DB.Tm_User.Where(a => a.TmUserPk == Id).FirstOrDefault();
            Session["CurrentUser"] = CurrentUser;
            CommonSession.CurretnUser = CurrentUser;
            return RedirectToAction("Index", "Tm_Product");
        }
    }
}