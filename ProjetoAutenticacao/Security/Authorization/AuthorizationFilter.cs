using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Security.Authorization
{
    public class AuthorizationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.Filters.Any(x => x.GetType() == typeof(AuthCheckAttribute))) return;

            //implementar autenticacao do token

            base.OnActionExecuting(context);
        }
    }
}
