using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoBackEnd.Enumeradores;

namespace TrabalhoBackEnd.Entidades
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public PerfilUsuario Tipo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}