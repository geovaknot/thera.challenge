using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Thera.Talent.Management.Web.Models
{
    public class Talent
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

        [DisplayName("Arquivo atual")]
        public string PathFile { get; set; }

        [Required(ErrorMessage = "O campo Arquivo é obrigatório.")]
        [DisplayName("Arquivo")]
        public HttpPostedFileBase File { get; set; }
    }
}