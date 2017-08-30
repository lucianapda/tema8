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
    [RoutePrefix("disciplina")]
    public class DisciplinaController : ApiController
    {
        private ServiceDisciplina serviceDisciplina = new ServiceDisciplina();

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