using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.Helpers;
using ProjetoAutenticacao.Models;
using ProjetoAutenticacao.Security;
using ProjetoAutenticacao.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : Controller
    {
        public AuthenticateController(Context db,AuthService auth)
        {
            _db = db;
            _auth = auth;
        }
        private readonly Context _db;
        private readonly AuthService _auth;

        [HttpPost]
        public async Task<object> UserAuthentication([FromBody]UserLogin user,[FromHeader]string appId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var app = await _db.Aplicativos.SingleOrDefaultAsync(x => x.AppId == appId);

            if(app == null) return Unauthorized("Aplicativo não identificado!");

            var userWithToken = await _auth.Authenticate(user.Login, user.Password,app.AppId);

            if (userWithToken == null) return Unauthorized("Login ou senha incorretos ou Usuários não cadastrados!");

            else return Ok(userWithToken) ;

        }
    
    }
}
