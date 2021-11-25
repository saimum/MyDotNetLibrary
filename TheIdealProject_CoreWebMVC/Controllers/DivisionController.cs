using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var list = await db.Division.ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var model = new Division();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Division model)
        {
            try
            {
                db.Division.Add(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(model);
            }
        }



        public async Task<IActionResult> AddOrEdit(int? employeeId)
        {
            ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
            ViewBag.IsEdit = employeeId == null ? false : true;
            if (employeeId == null)
            {
                return View();
            }
            else
            {
                var employee = await db.Division.FindAsync(employeeId);

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
        }
    }
}
