using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using Aplicacao.Entidades;
using Aplicacao.Seguranca;

namespace Aplicacao.Services
{
    public class ServiceAutenticacao
    {
        public Token ObterTokenCabecalho(HttpRequestMessage requisicao)
        {
            if (requisicao == null)
            {
                throw new ArgumentNullException(nameof(requisicao));
            }

            string tokenSerializado = null;
            var cabecalhoAutorizacao = requisicao.Headers.Authorization;
            if (cabecalhoAutorizacao != null && !string.IsNullOrWhiteSpace(cabecalhoAutorizacao.Scheme))
            {
                tokenSerializado = cabecalhoAutorizacao.Parameter;
            }

            if (string.IsNullOrWhiteSpace(tokenSerializado))
            {
                return null;
            }

            return new Token(tokenSerializado);
        }

        public Principal CriarIdentidadePrincipal(Token token)
        {
            var identidade = new Identidade(token);
            var principal = new Principal(identidade);
            return principal;
        }
    }
}