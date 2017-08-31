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
    [Autorizar(Perfis = PerfilUsuario.Usuario)]
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        private ServiceUsuario serviceUsuario = new ServiceUsuario();

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
    }
}
