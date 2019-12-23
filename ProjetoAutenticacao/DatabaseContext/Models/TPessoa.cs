using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.DatabaseContext.Models
{
    public class TPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public TUser Usuario { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
