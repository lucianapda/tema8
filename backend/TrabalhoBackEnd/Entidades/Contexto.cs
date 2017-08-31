using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Entidades
{
    public class Contexto : DbContext
    {
        public Contexto() : base()
        {
            
        }

        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }

    }
}