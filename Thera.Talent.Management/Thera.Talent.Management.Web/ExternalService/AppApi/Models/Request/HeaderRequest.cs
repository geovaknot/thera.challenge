namespace Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request
{
    public class HeaderRequest
    {
        public HeaderRequest(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; set; }
    }
}