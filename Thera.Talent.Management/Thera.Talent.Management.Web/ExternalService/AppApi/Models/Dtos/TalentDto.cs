using Microsoft.AspNetCore.Http;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Models.Dtos
{
    public class TalentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PathFile { get; set; }
        public IFormFile File { get; set; }
    }
}