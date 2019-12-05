using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.DatabaseContext.Models;
using ProjetoAutenticacao.Models;
using ProjetoAutenticacao.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Controllers
{
    [ApiController]
    [Route("/Controller")]
    public class UserController : Controller
    {
        public UserController(Context db)
        {
            _db = db;
        }
        private readonly Context _db;
        [HttpPost]
        public async Task<object> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var passwd = CryptographyHandler.GetMd5Hash(user.Password);
            var userModel = new TUser
            {
                 Login = user.Login,
                 Password = passwd
            };

            return Created("",null);
        }
    }
}
