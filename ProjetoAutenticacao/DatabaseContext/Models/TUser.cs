using System;

namespace ProjetoAutenticacao.DatabaseContext.Models
{
    public class TUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public TPessoa Pessoa { get; set; }
        public int Pessoa_Id { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
