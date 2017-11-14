using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Aplicacao.Enumeradores;
using Aplicacao.Services;

namespace Aplicacao.Seguranca
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AutorizarAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Representa os perfis que podem acessar este recurso
        /// </summary>
        public PerfilUsuario Perfis { get; set; }

        /// <summary>
        /// Ativa/Desativa este filtro
        /// </summary>
        public Boolean Ativo { get; set; }

        public AutorizarAttribute()
        {
            Ativo = true;
            Perfis = PerfilUsuario.Administrador;
        }


        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (!Ativo)
            {
                return;
            }

            var servicoAutenticacao = new ServiceAutenticacao();

            var token = servicoAutenticacao.ObterTokenCabecalho(filterContext.Request);

            var principal = servicoAutenticacao.CriarIdentidadePrincipal(token);
            if (Autorizar(token, principal))
            {
                filterContext.RequestContext.Principal = principal;
                Thread.CurrentPrincipal = principal;
            }
            else
            {
                AcessoNaoAutorizado(filterContext);
            }
        }

        protected virtual bool Autorizar(Token token, Principal principal)
        {
            bool acessoPermitido = true;
            if (Perfis != PerfilUsuario.Administrador)
            {
                acessoPermitido = principal.IsInRole(PerfilUsuario.Administrador | Perfis);
            }

            return token.Valido && acessoPermitido;
        }

        private void AcessoNaoAutorizado(HttpActionContext filterContext)
        {
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

    }
}