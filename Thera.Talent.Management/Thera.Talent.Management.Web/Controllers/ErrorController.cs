using System.Web.Mvc;

namespace Thera.Talent.Management.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string errorMessage)
        {
            ViewData["Error"] = errorMessage;
            return View();
        }
    }
}