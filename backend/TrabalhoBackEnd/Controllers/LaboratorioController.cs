using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
    [RoutePrefix("laboratorio")]
    public class LaboratorioController : ApiController
    {
        private ServiceLatoratorio serviceLatoratorio = new ServiceLatoratorio();

        /// <summary>
        /// Cadastrar um laboratório
        /// </summary>
        /// <param name="laboratorioDto"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Cadastrar(LaboratorioDto laboratorioDto)
        {
            try
            {
                serviceLatoratorio.Cadastrar(laboratorioDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Buscar todos os laboratórios cadastrados
        /// </summary>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
            try
            {
                return Ok(serviceLatoratorio.BuscarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualizar um laboratório cadastrado
        /// </summary>
        /// <param name="laboratorioDto"></param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Atualizar(LaboratorioDto laboratorioDto)
        {
            try
            {
                serviceLatoratorio.Atualizar(laboratorioDto);
                return Ok();
            }
            catch (ObjectNotFoundException e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletar um laboratório cadastrado
        /// </summary>
        /// <param name="idLaboratorio">Id laboratório a ser excluido</param> 
        /// <returns></returns>
        [Route("{idLaboratorio}")]
        [HttpDelete]
        public IHttpActionResult Delete(string idLaboratorio)
        {
            try
            {
                serviceLatoratorio.Deletar(Int32.Parse(idLaboratorio));
                return Ok();
            }
            catch (ObjectNotFoundException e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Buscar as informações do laboratório
        /// </summary>
        /// <param name="idLaboratorio">Id do laboratório</param>
        /// <returns></returns>
        [Route("{idLaboratorio}")]
        [HttpGet]
        public IHttpActionResult BuscarLaboratorio(string idLaboratorio)
        {
            try
            {
                
                return Ok(serviceLatoratorio.ObterLaboratorio(Int32.Parse(idLaboratorio)));
            }
            catch (ObjectNotFoundException e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}