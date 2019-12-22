using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ProjetoAutenticacao.Helpers
{
    public static class RequestHelper
    {
        public static string GetAppId(this Controller httpContext)
        {
            var appId = httpContext.Request.Headers["AppId"].FirstOrDefault();
            return appId;
        }
        public static JwtSecurityToken GetTokenOfHeader(this Controller httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (token == null) return null; 

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(token);
        }
    }
}
