using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Models
{
    public class UserWithToken
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
