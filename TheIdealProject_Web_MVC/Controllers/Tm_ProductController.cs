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
        [RequiredLogin]
        public ActionResult Index()
        {
            var list = db.Tm_Product.Where(p => p.TmProductPk > 1).ToList();
            return View(list);
        }
        #region Create
        [RequiredLogin]
        public ActionResult Create()
        {
            ViewBag.product_TmCategoryFk = new SelectList(db.Tm_Category, "TmCategoryPk", "CategoryName");
            ViewBag.product_TmUserFk_Creator = new SelectList(db.Tm_User, "TmUserPk", "UserName");
            ViewBag.product_TmUserFk_Modifier = new SelectList(db.Tm_User, "TmUserPk", "UserName");
            return View();
        }

        [RequiredLogin]
        [HttpPost]
        public ActionResult Create(Tm_Product model)
        {
            var DisplayMessage = "";
            //# Cehck validation
            var validationErrors = GetValidationErrors_ToCreate(model);
            if (validationErrors.Count == 0)
            {
                db.Tm_Product.Add(model);
                //db.SaveChanges();

                //# add to log
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationErrors)
                {
                    DisplayMessage = "|" + DisplayMessage + item + "|";
                }
            }
            ViewBag.DisplayMessage = DisplayMessage;

            ViewBag.product_TmCategoryFk = new SelectList(db.Tm_Category, "TmCategoryPk", "CategoryName", model.product_TmCategoryFk);
            ViewBag.product_TmUserFk_Creator = new SelectList(db.Tm_User, "TmUserPk", "UserName", model.product_TmUserFk_Creator);
            ViewBag.product_TmUserFk_Modifier = new SelectList(db.Tm_User, "TmUserPk", "UserName", model.product_TmUserFk_Modifier);
            return View(model);
        }

        public List<string> GetValidationErrors_ToCreate(Tm_Product model)
        {
            var list = new List<string>();
            if (db.Tm_Product.Where(m => m.productName == model.productName).Any())
            {
                list.Add("Duplicate Name");
            }
            return list;
        }


        #endregion
    }
}