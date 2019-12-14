using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Helpers
{
    public static class RequestHelper
    {
        public static string GetAppId(this Controller httpContext)
        {
            var appId = httpContext.Request.Headers["AppId"].FirstOrDefault();
            return appId;
        }
        public static string GetTokenOfHeader(this Controller httpContext)
        {
            var token = httpContext.Request.Headers["authorization"].FirstOrDefault();
            return token;
        }
    }
}
