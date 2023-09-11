using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Thera.Talent.Management.Web.ExternalService.AppApi.Interfaces;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;
using Thera.Talent.Management.Web.Models;

namespace Thera.Talent.Management.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IAppApiService _appApiService;

        public HomeController(
            IAppApiService appApiService)
        {
            _appApiService = appApiService;
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = new LoginRequest()
                    {
                        Login = login.Email,
                        Password = login.Password
                    };

                    var bodyAuth = await _appApiService.Login(request);

                    Session["acessToken"] = bodyAuth.AcessToken;
                    var expiration = (bodyAuth.Expires - DateTime.Now).Minutes;
                    Session.Timeout = expiration;

                    return RedirectToAction("Index");
                }

                return View(login);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(login);
            }
        }

        // GET: Home/Logout
        public ActionResult Logout()
        {
            ClearSession();
            return RedirectToAction("Login");
        }

        public ActionResult Index()
        {
            ValidateSession();

            return View();
        }

        public ActionResult About()
        {
            ValidateSession();

            ViewBag.Message = "O objetivo deste projeto é desenvolver uma aplicação web usando o .NET Framework 4.8 para gerenciar informações de um banco de talentos, com autenticação de dois tipos: autenticação via cookie para um aplicativo web MVC e autenticação via JWT (JSON Web Tokens) para uma API.";

            return View();
        }

        public ActionResult Contact()
        {
            ValidateSession();

            ViewBag.Message = "Página de Contato";

            return View();
        }
    }
}