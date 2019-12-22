using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.DatabaseContext.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Services
{
    public class TokenService
    {
        private readonly Context _db;

        public TokenService(Context db)
        {
            _db = db;
        }
        public async Task<TUser> GetUserFromToken(JwtSecurityToken token)
        {
            var id = Convert.ToInt32(token.Claims.FirstOrDefault(x => x.Issuer == "Id").Value);
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}
