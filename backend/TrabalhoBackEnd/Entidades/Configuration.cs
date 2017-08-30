using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

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
    }
}