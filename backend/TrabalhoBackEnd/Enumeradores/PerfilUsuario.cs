using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Enumeradores
{
    [Flags]
    public enum PerfilUsuario
    {
        [Description("Administrador")]
        Administrador = 0,

        [Description("Usuário")]
        Usuario = 1
    }
}