namespace ControleDeContatos.Helper
{
    public interface IEmail
    { 
        bool EnviarEmail(string email, string assunto, string mensagem);

    }
}
