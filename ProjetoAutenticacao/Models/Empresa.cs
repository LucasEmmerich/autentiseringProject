using System.ComponentModel.DataAnnotations;

namespace ProjetoAutenticacao.Models
{
    public class Empresa
    {
        [RegularExpression("^[1-9]{14}$")]
        public string CNPJ { get; set; }
    }
}
