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
    public class AgendamentoController : Controller
    {
        private readonly ServiceAgendamento _serviceAgendamento;
        private readonly ServiceDisciplina _serviceDisciplina;
        private readonly ServiceLaboratorio _serviceLaboratorio;

        public AgendamentoController(ServiceAgendamento serviceAgendamento,
            ServiceDisciplina serviceDisciplina,
            ServiceLaboratorio serviceLaboratorio)
        {
            _serviceAgendamento = serviceAgendamento;
            _serviceDisciplina = serviceDisciplina;
            _serviceLaboratorio = serviceLaboratorio;
        }
        // GET: Agendamentos/Agendamento
        public ActionResult Index()
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var lista = _serviceAgendamento.ObterTodas(value);
            return View(lista);
        }

        public ActionResult Cadastrar()
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            ViewBag.SelectListDisciplina = _serviceDisciplina.ObterTodas(value);
            ViewBag.SelectListLaboratorio = _serviceLaboratorio.ObterTodas(value);
           

            return View();
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

        [HttpPost]
        public ActionResult Cancelar(AgendamentoDto model)
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var agendamento = _serviceAgendamento.Cancelar(value, model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Liberar(AgendamentoDto model)
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var agendamento = _serviceAgendamento.Finalizar(value, model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Cadastrar(AgendamentoDto model)
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            model.HorarioInicial = DateTime.Parse(model.DiaInicial + " " + model.HoraInicial);
            model.HorarioFinal = DateTime.Parse(model.DiaFinal + " " + model.HoraFinal);


            var agendamento = _serviceAgendamento.Cadastrar(value, model);
            return RedirectToAction("Index");
        }
    }
}