using System.ComponentModel.DataAnnotations;

namespace Agenda_de_Contato.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato!")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage ="Digite um e-mail valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite o número do contato")]
        [Phone(ErrorMessage ="Digite um número valido!")]
        public string Numero { get; set; }
    }
}
