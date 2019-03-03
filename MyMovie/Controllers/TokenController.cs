﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IdentityModel.Tokens.Jwt;
using MyMovie.Helper;

namespace MyMovie.Controllers
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        public string Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string username, string password)
        {
            if(username == "authTest" && password == "test123!")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
