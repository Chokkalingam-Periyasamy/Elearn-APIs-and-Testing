using ElearnJWT.ElearnModel;
using ElearnJWT.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearnJWT.Provider
{
    public class AuthProvider:IAuthProvider
    {
        private readonly ICredentialsRepo obj;
        public elearnContext db = new elearnContext();
        public AuthProvider(ICredentialsRepo _obj)
        {
            obj = _obj;
        }
        /// <summary>
        /// This method is responsible for generating token as per the userinfo given by the authenticate method.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="_config"></param>
        /// <returns></returns>
        public string GenerateJSONWebToken(User userInfo, IConfiguration _config)
        {
            if (userInfo == null)
                return null;
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <summary>
        /// This method is used to authenticate user if the user credentials exist int the database and it will return the same.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        public dynamic AuthenticateUser(User login)
        {
            if (login == null)
            {
                return null;
            }
            try
            {
                User user = null;
                User a = new User();
                using (var db = new elearnContext())
                { 
                 a = (from i in db.Users where i.Email == login.Email && i.Password == login.Password select i)
               .FirstOrDefault();

                }

                if (a == null)
                { 
                    return null;
                }

                return a;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
