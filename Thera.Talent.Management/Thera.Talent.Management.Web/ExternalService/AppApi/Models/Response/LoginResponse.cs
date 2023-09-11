using Newtonsoft.Json;
using System;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Models.Response
{
    public class LoginResponse
    {
        [JsonProperty(PropertyName = "accessToken")]
        public string AcessToken { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public DateTime Expires { get; set; }
    }
}