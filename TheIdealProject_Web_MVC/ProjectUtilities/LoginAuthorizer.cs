using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheIdealProject_Web_MVC.ProjectUtilities
{
    public class LoginAuthorizer : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            CheckIfUserIsAuthenticated(filterContext);
        }

        private void CheckIfUserIsAuthenticated(AuthorizationContext filterContext)
        {
            //// Autohzies access to Ajax Metohod
            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    filterContext.HttpContext.Response.StatusCode = 401;
            //    filterContext.HttpContext.Response.End();
            //}

            // Autohzies access
            if (CommonSession.CurretnUser == null)
            {
                filterContext.Result = new RedirectResult("~/Access/Unauthorized");
            }
            else
            {
                return;
            }

            //-----------------Root Code------------
            //// If Result is null, we're OK: the user is authenticated and authorized. 
            //if (filterContext.Result == null)
            //{
            //    return;
            //}

            //// If here, you're getting an HTTP 401 status code. In particular,
            //// filterContext.Result is of HttpUnauthorizedResult type. Check Ajax here. 
            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (String.IsNullOrEmpty(View))
            //    {
            //        return;
            //    }
            //    var result = new ViewResult { ViewName = View, MasterName = Master };
            //    filterContext.Result = result;
            //}

            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    // For an Ajax request, just end the request 
            //    filterContext.HttpContext.Response.StatusCode = 401;
            //    filterContext.HttpContext.Response.End();
            //}
        }
    }
}