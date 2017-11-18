using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoFrontEnd.Models;
using TrabalhoFrontEnd.Services;

namespace TrabalhoFrontEnd.Controllers
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
        public ActionResult Index(LoginModel login)
        {
            if (_autenticar.Autenticar(login))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}