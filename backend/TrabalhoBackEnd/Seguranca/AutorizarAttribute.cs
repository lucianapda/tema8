using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TrabalhoBackEnd.Enumeradores;
using TrabalhoBackEnd.Services;

namespace TrabalhoBackEnd.Seguranca
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AutorizarAttribute: AuthorizationFilterAttribute
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
            if (servicoAutenticacao.Autenticar(token) != null)
            {
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