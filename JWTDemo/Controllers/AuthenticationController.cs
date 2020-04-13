using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTDemo.Models;
using JWTDemo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private IAuthentiCateServices _authentiCateServices;
        public AuthenticationController(IAuthentiCateServices authentiCateServices)
        {
            this._authentiCateServices = authentiCateServices;
        }
        // GET: api/<controller>

    

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]User users)
        {
            var user = _authentiCateServices.Authentication(users.UserName, users.Password);
            if (user == null)
            {
                return BadRequest(new { message = "username or password incorrect" });
            }
            return Ok(user);
        }

   
    }
}
