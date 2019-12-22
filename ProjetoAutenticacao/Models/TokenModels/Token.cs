namespace ProjetoAutenticacao.TokenModels
{
    public class Token
    {
        public string _token { get;}
        public int _validSeconds { get;}
        public Token(string token,int validSeconds)
        {
            _token = token;
            _validSeconds = validSeconds;
        }
    }
}
