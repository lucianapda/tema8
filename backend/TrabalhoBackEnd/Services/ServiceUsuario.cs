using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using AutoMapper;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Entidades;
using TrabalhoBackEnd.Enumeradores;
using TrabalhoBackEnd.Util;

namespace TrabalhoBackEnd.Services
{
    public class ServiceUsuario
    {
        private Contexto contexo = new Contexto();

        public void Cadastrar(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                throw  new ArgumentException(nameof(usuarioDto));
            }

            var usuario = Mapper.Map<UsuarioDto, Usuario>(usuarioDto);

            usuario.Senha = Utils.GenerateSHA512String(usuario.Senha);
            usuario.Perfis = new List<Perfil>()
            {
                contexo.Perfis.Where(x => x.Tipo == PerfilUsuario.Usuario).FirstOrDefault()
            };
            contexo.Usuarios.Add(usuario);
            contexo.SaveChanges();
        }

       
    }
}