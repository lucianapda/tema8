using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Aplicacao.Dto;
using Aplicacao.Enumeradores;
using Aplicacao.Seguranca;
using Aplicacao.Services;

namespace FrontEnd.Areas.Agendamentos.Controllers
{
    [Autorizar(Perfis = PerfilUsuario.Usuario)]
    public class DisciplinaController : Controller
    {
        private readonly ServiceDisciplina _serviceDisciplina;


        public DisciplinaController(ServiceDisciplina serviceDisciplina)
        {
            _serviceDisciplina = serviceDisciplina;
        }

        // GET: Agendamentos/Disciplina
        public ActionResult Index()
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var lista = _serviceDisciplina.ObterTodas(value);
            return View(lista);
        }

        public ActionResult Atualizar(int id)
        {
            var disciplina = _serviceDisciplina.Obter(Request.Cookies[FormsAuthentication.FormsCookieName].Value, id);
            return View(disciplina);
        }

        public ActionResult Remover(int id)
        {
            var disciplina = _serviceDisciplina.Remover(Request.Cookies[FormsAuthentication.FormsCookieName].Value, id);
            return RedirectToAction("Index");
        }

        public ActionResult Cadastrar()
        {
            var model = new DisciplinaDto();
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(DisciplinaDto model)
        {
            var disciplina = _serviceDisciplina.Cadastrar(Request.Cookies[FormsAuthentication.FormsCookieName].Value, model);

            if (disciplina)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Atualizar(DisciplinaDto model)
        {
            var disciplina = _serviceDisciplina.Atualizar(Request.Cookies[FormsAuthentication.FormsCookieName].Value, model);

            if (disciplina)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }

}