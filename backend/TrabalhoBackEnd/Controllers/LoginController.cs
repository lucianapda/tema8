using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Services;

namespace TrabalhoBackEnd.Controllers
{

    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        private ServiceAutenticacao serviceAutenticacao = new ServiceAutenticacao();

        /// <summary>
        /// Realizar o login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>TOKEN</returns>
        [Route("autenticar")]
        [HttpPost]
        public IHttpActionResult Autenticar(AutenticacaoDto login)
        {
            var usuario = serviceAutenticacao.Autenticar(login);

            if (usuario == null)
            {
                return BadRequest("Usuário ou senha incorretos.");
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add(
               "Authorization",
                String.Format("Bearer {0}", serviceAutenticacao.GerarToken(usuario).GerarJwt()));

            return new ResponseMessageResult(response);
        }

    }
}
