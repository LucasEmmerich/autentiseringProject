using ProjetoAutenticacao.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAutenticacao.Models
{
    public class User : IAutenticavel
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(5)]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
