using System;

namespace ProjetoAutenticacao.DatabaseContext.Models
{
    public class TAplicativo
    {
        public int Id { get; set; }
        public string Aplicativo { get; set; }
        public string AppId { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
