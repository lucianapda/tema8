using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoBackEnd.Enumeradores;

namespace TrabalhoBackEnd.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public Disciplina Disciplina { get; set; }
        public StatusAgendamento Status { get; set; }
    }
}