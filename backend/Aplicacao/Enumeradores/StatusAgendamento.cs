using System.ComponentModel;

namespace Aplicacao.Enumeradores
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