﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoBackEnd.Dto
{
    public class LaboratorioDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Bloco { get; set; }
        public int NumeroSala { get; set; }
        public int QtdMaquinas { get; set; }
    }
}