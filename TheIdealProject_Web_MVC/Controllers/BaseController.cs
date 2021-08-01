using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheIdealProject_Web_MVC.Models;

namespace TheIdealProject_Web_MVC.Controllers
{
    public class BaseController : Controller
    {
        protected DB_TheIdealPrtojectEntities DB = new DB_TheIdealPrtojectEntities();
    }
}