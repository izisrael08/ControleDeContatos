using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public String Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail")]
        public String Email { get; set; }
    }
}
