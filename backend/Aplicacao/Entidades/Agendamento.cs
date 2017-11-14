using System;
using Aplicacao.Enumeradores;

namespace Aplicacao.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public StatusAgendamento Status { get; set; }
    }
}