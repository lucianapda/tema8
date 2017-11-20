using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacao.Dto
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public int IdLaboratorio { get; set; }
        public int IdDisciplina { get; set; }
        public string Disciplina { get; set; }
        public string Laboratorio { get; set; }
        public string BlocoLaboratorio { get; set; }
        public int NumeroSalaLaboratorio { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public string StatusAgendamento { get; set; }
    }

}