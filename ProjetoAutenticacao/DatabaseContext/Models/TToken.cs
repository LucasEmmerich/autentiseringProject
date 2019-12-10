using System;

namespace ProjetoAutenticacao.DatabaseContext.Models
{
    public class TToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Validade { get; set; } 
    }
}
