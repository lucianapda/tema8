using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Services;

namespace TrabalhoBackEnd.Controllers
{
    [RoutePrefix("agendamento")]
    public class AgendamentoController : ApiController
    {
        private ServiceAgendamento serviceAgendamento = new ServiceAgendamento();


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
                serviceAgendamento.LiberarLaboratorio(agendamentoDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}