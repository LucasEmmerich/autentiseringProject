using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.DatabaseContext.Models;
using ProjetoAutenticacao.Models;
using ProjetoAutenticacao.Security;
using ProjetoAutenticacao.Security.Authorization;
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
        public UserController(Context db)
        {
            _db = db;
        }
        private readonly Context _db;

        [AuthCheck]
        [HttpPost]
        public async Task<object> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_db.Users.Any(x => x.Login == user.Login)) return BadRequest("Login já existente.");

            var passwd = CryptographyHandler.GetMd5Hash(user.Password);

            var userModel = new TUser
            {
                 Login = user.Login,
                 Password = passwd
            };

            _db.Users.Add(userModel);

            await _db.SaveChangesAsync();

            return Created("",null);
        }
    }
}
