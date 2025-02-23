using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        // usaremos atributos do data annotations para definir as regras de validação
        public int Id { get; set;}

        [Required(ErrorMessage = "Digite o nome do contato!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Email do contato!")]
        [EmailAddress(ErrorMessage = "Digite um Email que seja válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular do contato!")]
        [Phone(ErrorMessage = "Digite um número de Celular válido!")]
        public string Celular { get; set;  }

        public int? UsuarioId { get; set; }

        //[ValidateNever]
        public UsuarioModel? Usuario { get; set; }
    }
}
