using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheIdealProject_Web_MVC.Models;

namespace TheIdealProject_Web_MVC.Controllers
{
    public class Tm_Product1Controller : Controller
    {
        private DB_TheIdealPrtojectEntities db = new DB_TheIdealPrtojectEntities();

        // GET: Tm_Product1
        public ActionResult Index()
        {
            var tm_Product = db.Tm_Product.Include(t => t.Tm_Category).Include(t => t.Tm_User).Include(t => t.Tm_User1);
            return View(tm_Product.ToList());
        }

        // GET: Tm_Product1/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tm_Product tm_Product = db.Tm_Product.Find(id);
            if (tm_Product == null)
            {
                return HttpNotFound();
            }
            return View(tm_Product);
        }

        // GET: Tm_Product1/Create
        public ActionResult Create()
        {
            ViewBag.product_TmCategoryFk = new SelectList(db.Tm_Category, "TmCategoryPk", "CategoryName");
            ViewBag.product_TmUserFk_Creator = new SelectList(db.Tm_User, "TmUserPk", "UserName");
            ViewBag.product_TmUserFk_Modifier = new SelectList(db.Tm_User, "TmUserPk", "UserName");
            return View();
        }

        // POST: Tm_Product1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TmProductPk,Product_TlProductFk,productDevelperNote,productIsActive,productIsViewable,productIsDeleted,product_TmCategoryFk,productName,product_TmUserFk_Creator,productCreatedAt,product_TmUserFk_Modifier,productModifiedAt,productPrice")] Tm_Product tm_Product)
        {
            if (ModelState.IsValid)
            {
                db.Tm_Product.Add(tm_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_TmCategoryFk = new SelectList(db.Tm_Category, "TmCategoryPk", "CategoryName", tm_Product.product_TmCategoryFk);
            ViewBag.product_TmUserFk_Creator = new SelectList(db.Tm_User, "TmUserPk", "UserName", tm_Product.product_TmUserFk_Creator);
            ViewBag.product_TmUserFk_Modifier = new SelectList(db.Tm_User, "TmUserPk", "UserName", tm_Product.product_TmUserFk_Modifier);
            return View(tm_Product);
        }

        // GET: Tm_Product1/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tm_Product tm_Product = db.Tm_Product.Find(id);
            if (tm_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_TmCategoryFk = new SelectList(db.Tm_Category, "TmCategoryPk", "CategoryName", tm_Product.product_TmCategoryFk);
            ViewBag.product_TmUserFk_Creator = new SelectList(db.Tm_User, "TmUserPk", "UserName", tm_Product.product_TmUserFk_Creator);
            ViewBag.product_TmUserFk_Modifier = new SelectList(db.Tm_User, "TmUserPk", "UserName", tm_Product.product_TmUserFk_Modifier);
            return View(tm_Product);
        }

        // POST: Tm_Product1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TmProductPk,Product_TlProductFk,productDevelperNote,productIsActive,productIsViewable,productIsDeleted,product_TmCategoryFk,productName,product_TmUserFk_Creator,productCreatedAt,product_TmUserFk_Modifier,productModifiedAt,productPrice")] Tm_Product tm_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tm_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_TmCategoryFk = new SelectList(db.Tm_Category, "TmCategoryPk", "CategoryName", tm_Product.product_TmCategoryFk);
            ViewBag.product_TmUserFk_Creator = new SelectList(db.Tm_User, "TmUserPk", "UserName", tm_Product.product_TmUserFk_Creator);
            ViewBag.product_TmUserFk_Modifier = new SelectList(db.Tm_User, "TmUserPk", "UserName", tm_Product.product_TmUserFk_Modifier);
            return View(tm_Product);
        }

        // GET: Tm_Product1/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tm_Product tm_Product = db.Tm_Product.Find(id);
            if (tm_Product == null)
            {
                return HttpNotFound();
            }
            return View(tm_Product);
        }

        // POST: Tm_Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tm_Product tm_Product = db.Tm_Product.Find(id);
            db.Tm_Product.Remove(tm_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
