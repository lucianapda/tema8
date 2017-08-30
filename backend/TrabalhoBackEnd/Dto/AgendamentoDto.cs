using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Dto
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public int IdLaboratorio { get; set; }
        public int IdDisciplina { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
    }
}