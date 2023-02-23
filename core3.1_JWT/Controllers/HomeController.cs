using core3._1_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace core3._1_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("GetAction")]
        [Authorize]
        public IActionResult GetAction() {
            var currentUser = GetCurrentUser();

            return Ok(currentUser);
        }
        public UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return new UserModel()
                {
                    UserName = identity.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = identity.Claims.FirstOrDefault(m => m.Type == ClaimTypes.Email)?.Value
                };
            }
            else
            {
                return null;
            }
        }
    }
}
