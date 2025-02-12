using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        public String Login { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public String Senha { get; set; }
    }
}
