using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheIdealProject_CoreWebMVC.Models;

namespace TheIdealProject_CoreWebMVC.Controllers
{
    public class DivisionController : Controller
    {
        private readonly SQL_DbContext db;
        public DivisionController(IWebHostEnvironment webHostEnvironment, SQL_DbContext Context)
        {
            db = Context;
        }
        public IActionResult Index()
        {

            var list = db.Division.ToList();
            return View(list);
        }
    }
}
