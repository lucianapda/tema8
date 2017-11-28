using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Aplicacao.Dto;
using Aplicacao.Services;

namespace FrontEnd.Areas.Agendamentos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ServiceUsuario _serviceUsuario;


        public UsuarioController(ServiceUsuario serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
        }

        // GET: Agendamentos/Disciplina
        public ActionResult Index()
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var lista = _serviceUsuario.ObterTodas(value);
            if (lista == null)
            {
                lista = new List<UsuarioDto>();
            }
            return View(lista);
        }

        public ActionResult Atualizar(int id)
        {
            var user = _serviceUsuario.Obter(Request.Cookies[FormsAuthentication.FormsCookieName].Value, id);
            return View(user);
        }

        public ActionResult Remover(int id)
        {
            var user = _serviceUsuario.Remover(Request.Cookies[FormsAuthentication.FormsCookieName].Value, id);
            return RedirectToAction("Index");
        }

        public ActionResult Cadastrar()
        {
            var model = new UsuarioDto();
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioDto model)
        {
            var user = _serviceUsuario.Cadastrar(Request.Cookies[FormsAuthentication.FormsCookieName].Value, model);

            if (user)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Atualizar(UsuarioDto model)
        {
            var user = _serviceUsuario.Atualizar(Request.Cookies[FormsAuthentication.FormsCookieName].Value, model);

            if (user)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}