using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.DatabaseContext.Models;
using ProjetoAutenticacao.Enums;
using ProjetoAutenticacao.TokenModels;
using ProjetoAutenticacao.Models;
using ProjetoAutenticacao.Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Services
{
    public class AuthService
    {
        public AuthService(Context db)
        {
            _db = db;
        }
        private readonly Context _db;
        public async Task<Token> Authenticate(string username, string password, string appId)
        {
            var user = _db.Users.SingleOrDefault(x => x.Login == username);

            if (!CryptographyHandler.VerifyMd5Hash(password, user.Password)) return null;

            var app = _db.Aplicativos.SingleOrDefault(x => x.AppId == appId);

            if (user == null && app==null)
                return null;

            var expires = DateTime.UtcNow.AddDays(7);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("//encapsular depois");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id",user.Id.ToString()),
                    new Claim("login",user.Login.ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            _db.Tokens.Add(new TToken 
            {
                Token = token,
                Validade = expires
            });

            await _db.SaveChangesAsync();

            return new Token(token,(int)expires.Subtract(DateTime.Now).TotalSeconds);
        }

        public async Task<StatusTokenEnum> CheckTokenAsync(JwtSecurityToken jwtToken)
        {
            var token = jwtToken.RawData;
            if (string.IsNullOrWhiteSpace(token)) return StatusTokenEnum.Inválido;


            var tokenDb = await _db.Tokens.FirstOrDefaultAsync(x => x.Token == token);
            if (tokenDb == null) return StatusTokenEnum.Inválido;
            if (tokenDb != null && tokenDb.Validade < DateTime.Now) return StatusTokenEnum.Expirado;

            return StatusTokenEnum.Válido;
        }
    }
}
