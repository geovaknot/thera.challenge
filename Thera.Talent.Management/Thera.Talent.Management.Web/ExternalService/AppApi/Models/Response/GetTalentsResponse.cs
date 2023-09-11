using System.Collections.Generic;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Dtos;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Models.Response
{
    public class GetTalentsResponse
    {
        public IList<TalentDto> Talents { get; set; } = new List<TalentDto>();
    }
}