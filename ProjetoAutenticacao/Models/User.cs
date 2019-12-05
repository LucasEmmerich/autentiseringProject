using ProjetoAutenticacao.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAutenticacao.Models
{
    public class User : IAutenticavel
    {
        [Required(AllowEmptyStrings = false)]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
