using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Helpers
{
    public static class RequestHelper
    {
        public static string GetAppId(this Controller controller)
        {
            return controller.HttpContext.Request.Headers["AppId"].FirstOrDefault();
        }
    }
}
