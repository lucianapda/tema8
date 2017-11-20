using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Aplicacao.Services;

namespace FrontEnd.Areas.Agendamentos.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly ServiceAgendamento _serviceAgendamento;
        public AgendamentoController(ServiceAgendamento serviceAgendamento)
        {
            _serviceAgendamento = serviceAgendamento;
        }
        // GET: Agendamentos/Agendamento
        public ActionResult Index()
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var lista = _serviceAgendamento.ObterTodas(value);
            return View(lista);
        }

        public ActionResult Cancelar(int id)
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var agendamento = _serviceAgendamento.Obter(value, id);
            return View(agendamento);
        }

        public ActionResult Liberar(int id)
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var agendamento = _serviceAgendamento.Obter(value, id);
            return View(agendamento);
        }
    }
}