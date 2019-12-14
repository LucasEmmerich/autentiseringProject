using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAutenticacao.Helpers;
using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacao.Services;
using ProjetoAutenticacao.Enums;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ProjetoAutenticacao.Security.Authorization
{
    public class AuthorizationFilter:ActionFilterAttribute
    {
        public AuthorizationFilter(AuthService authService)
        {
            _authService = authService;
        }
        private readonly AuthService _authService;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool haveAuthAttr = ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.Any(x => x.AttributeType == typeof(AuthCheckAttribute));//pega attrbutes do método por reflexao

            if (!haveAuthAttr) return;

            var token = ((Controller)context.Controller).GetTokenOfHeader();

            StatusTokenEnum status = _authService.CheckTokenAsync(token).Result;

            if (status == StatusTokenEnum.Inválido || status == StatusTokenEnum.Expirado) context.Result = new UnauthorizedResult();
        }
    }
}
