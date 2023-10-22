using System.ComponentModel.DataAnnotations;

namespace agenda_contatos.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "O campo Senha deve ter entre 6 e 20 caracteres.")]
        public string Senha { get; set; }
    }
}
