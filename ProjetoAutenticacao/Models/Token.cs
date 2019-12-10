using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Models
{
    public class Token
    {
        public string _token { get;}
        public int _validSeconds { get;}
        public Token(string token,int validSeconds)
        {
            _token = token;
            _validSeconds = validSeconds;
        }
    }
}
