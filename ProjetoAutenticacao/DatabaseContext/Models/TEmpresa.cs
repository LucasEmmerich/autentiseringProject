using System;

namespace ProjetoAutenticacao.DatabaseContext.Models
{
    public class TEmpresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
