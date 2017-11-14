using System.Collections.Generic;
using Aplicacao.Enumeradores;

namespace Aplicacao.Entidades
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public PerfilUsuario Tipo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}