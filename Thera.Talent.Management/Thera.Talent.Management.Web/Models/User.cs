using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Dtos;

namespace Thera.Talent.Management.Web.Models
{
    public class User
    {
        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Perfil é obrigatório.")]
        [DisplayName("Perfil")]
        public Profile Profile { get; set; }
    }
}