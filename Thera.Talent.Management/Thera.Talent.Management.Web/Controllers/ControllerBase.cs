using System.Web.Mvc;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;

namespace Thera.Talent.Management.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected ControllerBase()
        {
        }

        protected HeaderRequest HeaderAuthenticatedRequest => new HeaderRequest(GetHeader(true));

        protected string GetHeader(bool authenticated)
        {
            ValidateSession();

            var token = Session["acessToken"]?.ToString();
            return token;
        }

        protected void ClearSession()
        {
            Session.Clear();
        }

        protected string GetUrlBase()
        {
            string urlBase = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}";
            return urlBase;
        }

        protected void ValidateSession()
        {
            var token = Session["acessToken"];

            if (token == null)
            {
                string url = $"{GetUrlBase()}/home/login";
                HttpContext.Response.Redirect(url);
            }
        }
    }
}