using System.Security.Cryptography; // Adicione este using
using System.Text;

namespace ControleDeContatos.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create(); // Correção: SHA1 em maiúsculas
            var encoding = new ASCIIEncoding();
            var arry = encoding.GetBytes(valor);

            arry = hash.ComputeHash(arry);

            var strHexa = new StringBuilder();

            foreach (var item in arry)
            {
                strHexa.Append(item.ToString("X2"));
            }
            return strHexa.ToString();
        }
    }
}