using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore7_withEF.Models;
using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Controllers
{
    public class MaterialController : Controller
    {
        protected readonly MainDbContext mainDb;
        public MaterialController(MainDbContext _mainDb, IHttpContextAccessor _httpContextAccessor)
        {
            mainDb = _mainDb;
        }

        public async Task<IActionResult> Index()
        {
          
            var list = await mainDb.Material.Include(u => u.Location).ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null || mainDb.Material == null)
            {
                return NotFound();
            }

            var Material = await mainDb.Material
                .Include(u => u.Location)
                .FirstOrDefaultAsync(m => m.PkMaterial == id);
            if (Material == null)
            {
                return NotFound();
            }

            return View(Material);
        }

        public IActionResult Create()
        {
            ViewBag.FkLocation = new SelectList(mainDb.Location, "PkLocation", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialRegistrationViewModel _Material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Material = mainDb.Material.Where(m => m.Name == _Material.Name).FirstOrDefault();
                    if (Material != null)
                    {
                        TempData["display_message"] = "Party already exist.";
                        return View(_Material);
                    }
                    else
                    {
                        Material = new Material();
                        Material.FkLocation = _Material.FkLocation;
                        Material.Name = _Material.Name;

                        Material.IsActive = true;
                        mainDb.Material.Add(Material);
                        mainDb.SaveChanges();

                        TempData["display_message"] = "Party registration successfull.";

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.FkLocation = new SelectList(mainDb.Location, "PkLocation", "Name", _Material.FkLocation);
                    return View(_Material);
                }
            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return View(_Material);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || mainDb.Material == null)
            {
                return NotFound();
            }

            var _Material = await mainDb.Material.Where(m => m.PkMaterial == id).Select(m => new MaterialRegistrationViewModel()
            {
                PkMaterial= m.PkMaterial,
                FkLocation = m.FkLocation,
                Name = m.Name,
            }).FirstOrDefaultAsync();

            if (_Material == null)
            {
                return NotFound();
            }
            ViewBag.FkLocation = new SelectList(mainDb.Location, "PkLocation", "Name", _Material.FkLocation);

            return View(_Material);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialRegistrationViewModel _Material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Material = mainDb.Material.Where(m => m.PkMaterial == _Material.PkMaterial).FirstOrDefault();
                    if (Material == null)
                    {
                        TempData["display_message"] = "Party does not exist.";
                        return View(_Material);
                    }
                    else
                    {
                        Material.FkLocation = _Material.FkLocation;
                        Material.Name = _Material.Name;

                        Material.IsActive = true;
                        mainDb.SaveChanges();

                        TempData["display_message"] = "Party updating successfull.";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.FkLocation = new SelectList(mainDb.Location, "PkLocation", "Name", _Material.FkLocation);

                    return View(_Material);
                }
            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return View(_Material);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || mainDb.Material == null)
            {
                return NotFound();
            }

            var Material = await mainDb.Material
                .Include(u => u.Location)
                .FirstOrDefaultAsync(m => m.PkMaterial == id);
            if (Material == null)
            {
                return NotFound();
            }

            return View(Material);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (mainDb.Material == null)
            {
                return Problem("Entity set 'MainDbContext.Material'  is null.");
            }
            var Material = await mainDb.Material.FindAsync(id);
            if (Material != null)
            {
                //mainDb.Material.Remove(Material);
                Material.IsActive = false;
            }
            else
            {
                return NotFound();
            }

            await mainDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MaterialExists(int id)
        {
            return (mainDb.Material?.Any(e => e.PkMaterial == id)).GetValueOrDefault();
        }

        //ViewModels
        public class MaterialRegistrationViewModel
        {
            public Int32? PkMaterial { get; set; }

            [Display(Name = "Location")]
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "{0} is required")]
            public Int32 FkLocation { get; set; }

            [Display(Name = "Name")]
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "{0} is required")]
            [MaxLength(50)] public String Name { get; set; }
        }
    }
}
