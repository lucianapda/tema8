using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<Perfil> Perfis { get; set; }


    }
}