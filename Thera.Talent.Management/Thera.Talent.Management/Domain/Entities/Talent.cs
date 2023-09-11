using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thera.Talent.Management.Domain.Entities
{
    public class Talent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PathFile { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}