using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Enumeradores;
using TrabalhoBackEnd.Seguranca;
using TrabalhoBackEnd.Services;


namespace TrabalhoBackEnd.Controllers
{
    //[Autorizar(Perfis = PerfilUsuario.Usuario)]
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        private ServiceUsuario serviceUsuario = new ServiceUsuario();

        /// <summary>
        /// Cadastrar usuário
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Cadastrar(UsuarioDto usuarioDto)
        {
            try
            {
                serviceUsuario.Cadastrar(usuarioDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Obter(int id)
        {
            try
            {
                return Ok(serviceUsuario.Obter(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route]
        [HttpGet]
        public IHttpActionResult ObterTodos()
        {
            try
            {
                return Ok(serviceUsuario.Obtertodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
