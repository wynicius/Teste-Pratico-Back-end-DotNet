using System.ComponentModel.DataAnnotations;

namespace agenda_contatos.Models
{
    public class Usuario
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Ter um nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo usuáio deve ter no máximo 50 caracteres.")]
        public string? NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "Ter um email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Ter um telefone é obrigatório.")]
        [Phone(ErrorMessage = "O campo Telefone deve ser um número de telefone válido.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Ter uma senha é obrigatório.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "O campo Senha deve ter entre 6 e 20 caracteres.")]
        public string? Senha { get; set; }
        public string? Role { get; set; }
    }
}
