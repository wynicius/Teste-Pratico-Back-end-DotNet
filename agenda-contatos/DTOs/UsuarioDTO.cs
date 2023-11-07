using System.ComponentModel.DataAnnotations;

namespace agenda_contatos.DTOs
{
    public class UsuarioDTO
    {
        public int? Id { get; set; }

        [StringLength(50, ErrorMessage = "O campo usuáio deve ter no máximo 50 caracteres.")]
        public string? NomeDeUsuario { get; set; }

        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "O campo Telefone deve ser um número de telefone válido.")]
        public string? Telefone { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "O campo Senha deve ter entre 6 e 20 caracteres.")]
        public string? Role { get; set; }
        
    }
}