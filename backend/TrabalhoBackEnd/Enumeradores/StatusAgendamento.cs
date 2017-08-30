using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Enumeradores
{
    public enum StatusAgendamento
    {
        [Description("Aberto")]
        Aberto = 0,
        [Description("Cancelado")]
        Cancelado = 1,
        [Description("Concluído")]
        Concluido = 2

    }
}