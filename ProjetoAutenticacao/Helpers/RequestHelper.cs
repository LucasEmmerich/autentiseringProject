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
            //implementar
            var a = httpContext.Request.Headers ;
            return null;
        }
    }
}
