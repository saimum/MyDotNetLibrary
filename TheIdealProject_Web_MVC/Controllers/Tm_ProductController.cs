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
    public class TM_ProductController : BaseController
    {
        [RequiredLogin]
        public ActionResult Index()
        {
            var list = db.TM_Product.Where(p => p.TM_ProductPk > 1).ToList();
            return View(list);
        }
        #region Create
        [RequiredLogin]
        public ActionResult Create()
        {
            ViewBag.Product_TM_SubCategoryFk = new SelectList(db.TM_SubCategory, "TM_SubCategoryFk", "SubCategory_Name");
            return View();
        }

        [RequiredLogin]
        [HttpPost]
        public ActionResult Create(TM_Product model)
        {
            var DisplayMessage = "";
            //# Cehck validation
            var validationErrors = GetValidationErrors_ToCreate(model);
            if (validationErrors.Count == 0)
            {
                //# add model
                db.TM_Product.Add(model);
                //db.SaveChanges();

                //# add log
                var log_model = GetLogModel(model);
                db.TL_Product.Add(log_model);
                //db.SaveChanges();

                //# update model for log
                model.TL_ProductFk = log_model.TL_ProductPk;
                //db.SaveChanges();
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

            ViewBag.Product_TM_SubCategoryFk = new SelectList(db.TM_SubCategory, "TM_SubCategoryFk", "SubCategory_Name", model.Product_TM_SubCategoryFk);
            return View(model);
        }

        public TL_Product GetLogModel(TM_Product model)
        {

            PropertyInfo[] modelProperties = model.GetType().GetProperties();
            var log_model = new TL_Product();
            log_model.TM_ProductFk = model.TM_ProductPk;
            //PropertyInfo[] logProps = log_model.GetType().GetProperties();
            //Type target = typeof(T);
            //var x = Activator.CreateInstance(log_model.GetType(), false);

            foreach (PropertyInfo modelProp in modelProperties)
            {
                var value = model.GetType().GetProperty(modelProp.Name).GetValue(model, null);
                var propertyInfo = log_model.GetType().GetProperty(modelProp.Name);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(log_model, value, null);
                }
            }

            //Type objectType = model.GetType();
            //Type target = new TL_Product().GetType();
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
        public List<string> GetValidationErrors_ToCreate(TM_Product model)
        {
            var list = new List<string>();
            if (db.TM_Product.Where(m => m.Product_Code == model.Product_Code).Any())
            {
                list.Add("Duplicate Product_Code");
            }
            if (db.TM_Product.Where(m => m.Product_Name == model.Product_Name).Any())
            {
                list.Add("Duplicate Product_Name");
            }
            return list;
        }


        #endregion
    }
}