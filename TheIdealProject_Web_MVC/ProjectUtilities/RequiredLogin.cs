using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheIdealProject_Web_MVC.ProjectUtilities
{
    public class RequiredLogin : AuthorizeAttribute
    {
        //public RequiredLogin(params string[] roles)
        //{
        //}
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            if (CommonSession.CurretnUser != null)
            {
                authorize = true;
            }
            if (httpContext.Request.IsAjaxRequest())
            {
                authorize = true;
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Access/Unauthorized");
        }
    }
}