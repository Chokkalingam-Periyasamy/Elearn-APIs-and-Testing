using ElearnJWT.ElearnModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnJWT.Provider
{
    public interface IAuthProvider
    {
        public string GenerateJSONWebToken(User userInfo, IConfiguration _config);
        public dynamic AuthenticateUser(User login);
    
}
}
