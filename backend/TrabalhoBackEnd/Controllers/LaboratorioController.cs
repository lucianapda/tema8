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
    [RoutePrefix("laboratorio")]
    public class LaboratorioController : ApiController
    {
        private ServiceLatoratorio serviceLatoratorio = new ServiceLatoratorio();

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

        [Route]
        [HttpPut]
        public IHttpActionResult Atualizar(LaboratorioDto laboratorioDto)
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

        [Route("idLaboratorio")]
        [HttpDelete]
        public IHttpActionResult Delete(string idLaboratorio)
        {
            try
            {
                serviceLatoratorio.Deletar(Int32.Parse(idLaboratorio));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("idLaboratorio")]
        public IHttpActionResult BuscarLaboratorio(string idLaboratorio)
        {
            try
            {
                serviceLatoratorio.ObterLaboratorio(Int32.Parse(idLaboratorio));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}