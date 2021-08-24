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
        DB_TheIdealDatabaseEntities DB = new DB_TheIdealDatabaseEntities();
        public ActionResult Index()
        {
            return View(DB.TM_User.Where(a => a.TM_UserPk > 1).ToList());
        }
        public ActionResult Login(long Id)
        {
            var CurrentUser = DB.TM_User.Where(a => a.TM_UserPk == Id).FirstOrDefault();
            Session["CurrentUser"] = CurrentUser;
            CommonSession.CurretnUser = CurrentUser;
            return RedirectToAction("Index", "Tm_Product");
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}