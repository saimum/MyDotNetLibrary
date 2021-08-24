using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheIdealProject_Web_MVC.Models;

namespace TheIdealProject_Web_MVC.ProjectUtilities
{
    public static class CommonSession
    {
        public static TM_User CurretnUser { get; set; }
    }
}