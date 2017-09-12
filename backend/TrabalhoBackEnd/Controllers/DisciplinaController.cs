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
    [RoutePrefix("disciplina")]
    public class DisciplinaController : ApiController
    {
        private ServiceDisciplina serviceDisciplina = new ServiceDisciplina();


        /// <summary>
        /// Cadastrar uma disciplina
        /// </summary>
        /// <param name="disciplinaDto"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult CadastrarDisciplina(DisciplinaDto disciplinaDto)
        {
            try
            {
                serviceDisciplina.Cadastrar(disciplinaDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
        /// <summary>
        /// Buscar todas as disciplinas cadastradas
        /// </summary>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
            try
            {
                return Ok(serviceDisciplina.BuscarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Atualizar uma disciplina cadastrada
        /// </summary>
        /// <param name="disciplinaDto"></param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult AtualizarDisciplia(DisciplinaDto disciplinaDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Deletar uma disciplina cadastrada
        /// </summary>
        /// <param name="idDisciplina">Id da disciplina</param>
        /// <returns></returns>
        [Route("idDisciplina")]
        [HttpDelete]
        public IHttpActionResult Delete(string idDisciplina)
        {
            try
            {
                serviceDisciplina.Deletar(Int32.Parse(idDisciplina));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Buscar uma discipliona
        /// </summary>
        /// <param name="idDisciplina">Id da disciplina a ser buscado as informações</param>
        /// <returns></returns>
        [Route("idDisciplina")]
        [HttpGet]
        public IHttpActionResult Buscar(string idDisciplina)
        {
            try
            {
                serviceDisciplina.Obter(Int32.Parse(idDisciplina));
                return Ok();
            }
            catch (InvalidCastException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}