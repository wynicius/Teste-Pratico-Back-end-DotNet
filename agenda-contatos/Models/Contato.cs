using System.ComponentModel.DataAnnotations;

namespace agenda_contatos.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo Telefone deve conter apenas números.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "(DDD)(x.xxxx.xxxx).")]
        public string Telefone { get; set; }
    }
}
