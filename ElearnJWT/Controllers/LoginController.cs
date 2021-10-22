﻿using ElearnJWT.ElearnModel;
using ElearnJWT.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration config;
        private readonly IAuthProvider ap;
        string tokenString = "";
        public elearnContext db = new elearnContext();
        public LoginController(IConfiguration config, IAuthProvider ap)
        {
            this.config = config;
            this.ap = ap;
        }
        [HttpPost("UserDetail")]
        public async Task<ActionResult<User>> GetDetail(User u)
        {
            using (var db = new elearnContext())
            {
               User ua = await (from i in db.Users where i.Email== u.Email && i.Password == u.Password select i).FirstOrDefaultAsync();
                return Ok(ua);
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            
            if (login == null)
            {
                return BadRequest();
            }
            try
            {

                IActionResult response = Unauthorized();
                User user = ap.AuthenticateUser(login);         //authenticatin the user first

                if (user != null)
                {
                    var tokenString = ap.GenerateJSONWebToken(user, config);        //generating token only if the user is authenticated
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddMinutes(15);
                    Response.Cookies.Append("Valid", tokenString, cookie);
                    response = Ok(tokenString);

                }

                return response;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpGet("CheckAuthentication")]
        [Authorize]
        [AllowAnonymous]
        public IActionResult CheckAuthentication()
        {
            if (Request.Cookies["valid"] != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
           
        }

    }
}
