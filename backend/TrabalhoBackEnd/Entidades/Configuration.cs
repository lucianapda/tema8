using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TrabalhoBackEnd.Enumeradores;
using TrabalhoBackEnd.Util;

namespace TrabalhoBackEnd.Entidades
{
    public class Configuration : DbMigrationsConfiguration<Contexto>
    {
        public Configuration()
        {
            CommandTimeout = int.MaxValue;
            AutomaticMigrationsEnabled = false;
            ContextKey = typeof(Contexto).FullName;
            MigrationsDirectory = "Migrations";

        }

        protected override void Seed(Contexto contexto)
        {
            if (!contexto.Database.Exists())
            {
                var lista = new List<Perfil>();

                lista.Add(new Perfil()
                {
                    Id = 1,
                    Nome = "Admin",
                    Tipo = PerfilUsuario.Administrador
                });

                lista.Add(new Perfil()
                {
                    Id = 2,
                    Nome = "Usuário",
                    Tipo = PerfilUsuario.Usuario
                });

                contexto.Perfis.AddOrUpdate(x => x.Id, lista.FirstOrDefault(), lista.LastOrDefault());

                contexto.Usuarios.AddOrUpdate(x => x.Id, new Usuario()
                {
                    Id = 1,
                    Login = "admin",
                    Nome = "Administrador",
                    Perfis = lista,
                    Senha = Utils.GenerateSHA512String("123")
                });
            }
        }
    }
}