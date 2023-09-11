namespace Thera.Talent.Management.Web.ExternalService.AppApi.Models.Dtos
{
    public enum Profile
    {
        Readers,
        Secretaries,
        Administrators
    }
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
    }
}