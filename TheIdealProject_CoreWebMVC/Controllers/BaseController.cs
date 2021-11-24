using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheIdealProject_CoreWebMVC.Models;

namespace TheIdealProject_CoreWebMVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly SQL_DbContext dbContext;
        public BaseController(IWebHostEnvironment webHostEnvironment, SQL_DbContext Context)
        {
            dbContext = Context;
        }
    }
}
