using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Enumeradores;
using TrabalhoBackEnd.Services;

namespace TrabalhoBackEnd.Controllers
{
    [RoutePrefix("agendamento")]
    public class AgendamentoController : ApiController
    {
        private ServiceAgendamento serviceAgendamento = new ServiceAgendamento();

        [Route]
        [HttpGet]
        public IHttpActionResult RetornarAgendamentos()
        {
            try
            {
                return Ok(serviceAgendamento.BuscarTodosAgendamento());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Cadastrar(AgendamentoDto agendamentoDto)
        {
            try
            {
                serviceAgendamento.Cadastrar(agendamentoDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("liberar")]
        [HttpPut]
        public IHttpActionResult LiberarAgendamento(AgendamentoDto agendamentoDto)
        {
            try
            {
                serviceAgendamento.AlterarStatusLaboratorio(agendamentoDto, StatusAgendamento.Cancelado);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("finalizar")]
        [HttpPut]
        public IHttpActionResult FinalizarAgendamento(AgendamentoDto agendamentoDto)
        {
            try
            {
                serviceAgendamento.AlterarStatusLaboratorio(agendamentoDto, StatusAgendamento.Concluido);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}