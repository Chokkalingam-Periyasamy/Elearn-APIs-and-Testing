﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnJWT.Repository
{
    public interface ICredentialsRepo
    {
        public Dictionary<string, string> GetCredentials();
    }
}
