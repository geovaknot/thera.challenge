using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Dtos;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
    }
}