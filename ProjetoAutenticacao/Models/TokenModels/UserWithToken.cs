using ProjetoAutenticacao.Models;

namespace ProjetoAutenticacao.TokenModels
{
    public class UserWithToken
    {
        public string _token { get;}
        public int _validSeconds { get; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CpfCnpj { get; set; }
        public string Login { get; set; }
        public UserWithToken(string token,int validSeconds,User user)
        {
            _token = token;
            _validSeconds = validSeconds;
            Nome = user.Nome;
            Email = user.Email;
            Telefone = user.Telefone;
            CpfCnpj = user.CpfCnpj;
            Login = user.Login;
        }
    }
}
