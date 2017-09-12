using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Enumeradores;
using TrabalhoBackEnd.Seguranca;
using TrabalhoBackEnd.Services;

namespace TrabalhoBackEnd.Controllers
{
    [Autorizar(Perfis = PerfilUsuario.Usuario)]
    [RoutePrefix("agendamento")]
    public class AgendamentoController : ApiController
    {
        private ServiceAgendamento serviceAgendamento = new ServiceAgendamento();

        /// <summary>
        /// Buscar todos os agendamentos futuros
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cadastrar um novo agendamento de laboratório
        /// </summary>
        /// <param name="agendamentoDto"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Liberar/Cancelar o agendamento do laboratório
        /// </summary>
        /// <param name="agendamentoDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Finalizar o uso do laboratórios
        /// </summary>
        /// <param name="agendamentoDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Buscar agendamentos do laboratório, ordenando do ultimo agendamento para o primeiro
        /// </summary>
        /// <param name="idLaboratorio"></param>
        /// <returns></returns>
        [Route("{idLaboratorio}")]
        [HttpGet]
        public IHttpActionResult ObterAgendamentoLaboratorio(int idLaboratorio)
        {
            try
            {
                return Ok(serviceAgendamento.ConsultarAgendamento(idLaboratorio, 0));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Buscar agendamentos do laboratório por uma disciplina, ordenando do ultimo agendamento para o primeiro
        /// </summary>
        /// <param name="idDisciplina"></param>
        /// <returns></returns>
        [Route("{idDisciplina}")]
        [HttpGet]
        public IHttpActionResult ObterAgendamentoDisciplina(int idDisciplina)
        {
            try
            {
                return Ok(serviceAgendamento.ConsultarAgendamento(0, idDisciplina));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Buscar o agendamento por uma disciplina e um laboratório, ordenando do ultimo agendamento para o primeiro
        /// </summary>
        /// <param name="idLaboratorio"></param>
        /// <param name="idDisciplina"></param>
        /// <returns></returns>
        [Route("{idLaboratorio}/{idDisciplina}")]
        [HttpGet]
        public IHttpActionResult ObterAgendamento(int idLaboratorio, int idDisciplina)
        {
            try
            {
                return Ok(serviceAgendamento.ConsultarAgendamento(idLaboratorio, idDisciplina));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}