using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.DatabaseContext.Models;
using ProjetoAutenticacao.Models;
using ProjetoAutenticacao.Security;
using ProjetoAutenticacao.Security.Authorization;
using ProjetoAutenticacao.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public UserController(Context db,CadastroService cadService)
        {
            _db = db;
            _cadastroService = cadService;
        }
        private readonly Context _db;
        private readonly CadastroService _cadastroService;

        [AuthCheck]
        [HttpPost]
        public async Task<object> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_db.Users.Any(x => x.Login == user.Login)) return BadRequest("Nome de Usuário já cadastrado.");

            user.Password = CryptographyHandler.GetMd5Hash(user.Password);

            await _cadastroService.CadastrarUsuario(user);

            return Created("",null);
        }
    }
}
