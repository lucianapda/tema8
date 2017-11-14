using System;
using System.ComponentModel;

namespace Aplicacao.Enumeradores
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