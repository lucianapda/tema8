using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Policy;
using System.Web;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Entidades;
using TrabalhoBackEnd.Seguranca;
using TrabalhoBackEnd.Util;

namespace TrabalhoBackEnd.Services
{
    public class ServiceAutenticacao
    {
        private Contexto contexo = new Contexto();

        public Usuario Autenticar(AutenticacaoDto login)
        {
            if (string.IsNullOrEmpty(login.Login))
            {
                throw new ArgumentNullException("É necessário informar o login.");
            }

            if (string.IsNullOrEmpty(login.Senha))
            {
                throw new ArgumentNullException("É necessário informar a senha.");
            }

            var hashSenha = Utils.GenerateSHA512String(login.Senha);

            var usuario = contexo.Usuarios.Where(x => x.Login == login.Login && x.Senha == hashSenha).FirstOrDefault();

            return usuario;
        }

        public Usuario Autenticar(Token token)
        {
            if (token == null || !token.Valido)
            {
                return null;
            }

            var idUsuarioClaim = token.Claims
                .FirstOrDefault(claim => claim.Type.Equals(Claims.Id));

            int idUsuario;
            int.TryParse(idUsuarioClaim?.Value, out idUsuario);

            return contexo.Usuarios.Where
                (usuario => usuario.Id == idUsuario)
                .FirstOrDefault();
        }


        public Token GerarToken(Usuario usuario)
        {
            var token = new Token();
            token.ExpiraEm = DateTime.UtcNow.AddHours(2);

            token.AdicionarClaim(new Claim(Claims.Id, Convert.ToString(usuario.Id)));
            token.AdicionarClaim(new Claim(Claims.Nome, usuario.Nome));
            token.AdicionarClaim(new Claim(Claims.Login, usuario.Login));

            if (usuario.Perfis != null)
            {
                foreach (var perfil in usuario.Perfis)
                {
                    var perfilClaim = new Claim(ClaimTypes.Role, perfil.Tipo.ObterValor().ToString());
                    token.AdicionarClaim(perfilClaim);
                }
            }

            return token;
        }

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