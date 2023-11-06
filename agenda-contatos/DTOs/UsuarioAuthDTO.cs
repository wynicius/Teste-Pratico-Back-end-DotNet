using System.ComponentModel.DataAnnotations;

namespace agenda_contatos.DTOs
{
    public class UsuarioAuthDTO
    {
        public int? Id { get; set; }

        public string? NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "Ter um email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string? Email { get; set; }

        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Ter uma senha é obrigatório.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "O campo Senha deve ter entre 6 e 20 caracteres.")]
        public string? Senha { get; set; }

        public string? Role { get; set; }
    }
}
