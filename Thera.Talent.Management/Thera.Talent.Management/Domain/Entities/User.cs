namespace Thera.Talent.Management.Domain.Entities
{
    public enum Profile
    {
        Readers,
        Secretaries,
        Administrators
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
    }
}