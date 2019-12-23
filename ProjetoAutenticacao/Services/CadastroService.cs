using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.DatabaseContext.Models;
using ProjetoAutenticacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAutenticacao.Services
{
    public class CadastroService
    {
        private readonly Context _db;
        public CadastroService(Context db)
        {
            _db = db;
        }
        public async Task CadastrarUsuario(User user)
        {
            var pessoaModel = new TPessoa
            {
                CpfCnpj = user.CpfCnpj,
                Email = user.Email,
                Nome = user.Nome,
                Telefone = user.Telefone
            };

            var userModel = new TUser
            {
                Login = user.Login,
                Password = user.Password,
                Pessoa = pessoaModel             
            };

            _db.Pessoas.Add(pessoaModel);
            _db.Users.Add(userModel);

            await _db.SaveChangesAsync();

        }
    }
}
