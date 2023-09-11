using System.Collections.Generic;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Dtos;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Models.Response
{
    public class GetUsersResponse
    {
        public IList<UserDto> Users { get; set; } = new List<UserDto>();
    }
}