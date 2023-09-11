using Newtonsoft.Json;
using System;

namespace Thera.Talent.Management.Authorization
{
    public class TokenData
    {
        [JsonProperty(PropertyName = "accessToken")]
        public string AcessToken { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public DateTime Expires { get; set; }
    }
}