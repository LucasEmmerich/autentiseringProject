using ProjetoAutenticacao.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAutenticacao.Models
{
    public class User
    {
        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [RegularExpression("^(([a-zA-Z0-9]*\\@[a-zA-Z0-9]*\\.[a-zA-Z]{1,10})|())$",ErrorMessage = "Email Incorreto! ")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("^[0-9]{2}9?[0-9]{8}$",ErrorMessage = "Telefone deve ser enviado sem formatação e deve conter 10 ou 11 dígitos.")]
        public string Telefone { get; set; }
        [RegularExpression("^(([0-9]{11})|([0-9]{14}))$",ErrorMessage = "Cpf ou Cnpj devem ter 11 ou 14 dígitos respectivamentes (somente números e sem formatações)!")]
        public string CpfCnpj { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(5)]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
