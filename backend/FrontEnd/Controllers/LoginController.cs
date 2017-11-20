using System;
using System.Web;
using FrontEnd.Models;
using FrontEnd.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private readonly AutenticarService _autenticar;
        public LoginController(AutenticarService autenticar)
        {
            _autenticar = autenticar;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var token = _autenticar.Autenticar(model);
            if (!String.IsNullOrEmpty(token))
            {
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,token));
                return RedirectToAction("Index", "Home", new { Area = "Agendamentos" });
            }

            return View();
        }

        public ActionResult Logoff(LoginModel model)
        {
            return RedirectToAction("Index");
        }
    }
}