using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                //# add model
                db.Tm_Product.Add(model);
                db.SaveChanges();

                //# add log
                var log_model = GetLogModel(model);
                db.Tl_Product.Add(log_model);
                db.SaveChanges();

                //# update model for log
                model.Product_TlProductFk = log_model.Tl_ProductPk;
                db.SaveChanges();
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

        public Tl_Product GetLogModel(Tm_Product model)
        {

            PropertyInfo[] modelProperties = model.GetType().GetProperties();
            var log_model = new Tl_Product();
            log_model.Product_TmProductFk = model.TmProductPk;
            //PropertyInfo[] logProps = log_model.GetType().GetProperties();
            //Type target = typeof(T);
            //var x = Activator.CreateInstance(log_model.GetType(), false);

            foreach (PropertyInfo modelProp in modelProperties)
            {
                var value = model.GetType().GetProperty(modelProp.Name).GetValue(model, null);
                var propertyInfo = log_model.GetType().GetProperty(modelProp.Name);
                if (propertyInfo!=null)
                {
                    propertyInfo.SetValue(log_model, value, null);
                }
            }

            //Type objectType = model.GetType();
            //Type target = new Tl_Product().GetType();
            //var x = Activator.CreateInstance(target, false);
            //var z = from source in objectType.GetMembers().ToList()
            //        where source.MemberType == MemberTypes.Property
            //        select source;
            //var d = from source in target.GetMembers().ToList()
            //        where source.MemberType == MemberTypes.Property
            //        select source;
            //List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
            //   .ToList().Contains(memberInfo.Name)).ToList();
            //PropertyInfo propertyInfo;
            //object value;
            //foreach (var memberInfo in members)
            //{
            //    propertyInfo = target.GetProperty(memberInfo.Name);
            //    value = model.GetType().GetProperty(memberInfo.Name).GetValue(model, null);
            //    propertyInfo.SetValue(x, value, null);
            //}






            return log_model;
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