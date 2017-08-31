using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Dto
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<PerfilDto> Perfis { get; set; }
    }
}