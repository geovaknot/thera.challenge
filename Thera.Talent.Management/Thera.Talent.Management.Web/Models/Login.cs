using System.ComponentModel.DataAnnotations;

namespace Thera.Talent.Management.Web.Models
{
    public class Login
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login do usuário", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}