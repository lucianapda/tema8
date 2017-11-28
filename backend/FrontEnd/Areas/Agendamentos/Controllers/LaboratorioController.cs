﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Aplicacao.Dto;
using Aplicacao.Services;

namespace FrontEnd.Areas.Agendamentos.Controllers
{
    public class LaboratorioController : Controller
    {
        private readonly ServiceLaboratorio _serviceLaboratorio;


        public LaboratorioController(ServiceLaboratorio serviceLaboratorio)
        {
            _serviceLaboratorio = serviceLaboratorio;
        }

        // GET: Agendamentos/Disciplina
        public ActionResult Index()
        {
            var value = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var lista = _serviceLaboratorio.ObterTodas(value);
            return View(lista);
        }

        public ActionResult Atualizar(int id)
        {
            var disciplina = _serviceLaboratorio.Obter(Request.Cookies[FormsAuthentication.FormsCookieName].Value, id);
            return View(disciplina);
        }

        public ActionResult Remover(int id)
        {
            var laboratorio = _serviceLaboratorio.Remover(Request.Cookies[FormsAuthentication.FormsCookieName].Value, id);
            return RedirectToAction("Index");
        }

        public ActionResult Cadastrar()
        {
            var model = new LaboratorioDto();
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(LaboratorioDto model)
        {
            var LaboratorioDto = _serviceLaboratorio.Cadastrar(Request.Cookies[FormsAuthentication.FormsCookieName].Value, model);

            if (LaboratorioDto)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Atualizar(LaboratorioDto model)
        {
            var LaboratorioDto = _serviceLaboratorio.Atualizar(Request.Cookies[FormsAuthentication.FormsCookieName].Value, model);

            if (LaboratorioDto)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}