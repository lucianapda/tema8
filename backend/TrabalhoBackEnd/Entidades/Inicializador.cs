using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Entidades
{
    
    public class Inicializador : MigrateDatabaseToLatestVersion<Contexto,Configuration>
    {
        public override void InitializeDatabase(Contexto contexto)
        {
            var databaseExists = contexto.Database.Exists();
            base.InitializeDatabase(contexto);
        }
    }
}