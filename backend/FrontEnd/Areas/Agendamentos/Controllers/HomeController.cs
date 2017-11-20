using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Areas.Agendamentos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Agendamentos/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}