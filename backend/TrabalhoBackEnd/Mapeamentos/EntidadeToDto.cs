using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Entidades;

namespace TrabalhoBackEnd.Mapeamentos
{
    public class EntidadeToDto : Profile
    {
        public EntidadeToDto() : base("DomainToViewModelMappings")
        {

        }

        protected void Configure()
        {
            this.CreateMap<Disciplina, DisciplinaDto>();
            

        }
    }
}