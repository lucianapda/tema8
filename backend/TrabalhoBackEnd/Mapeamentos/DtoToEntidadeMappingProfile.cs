using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Entidades;

namespace TrabalhoBackEnd.Mapeamentos
{
    public class DtoToEntidadeMappingProfile :Profile
    {
        public DtoToEntidadeMappingProfile() : base("ViewModelToDomainMappings")
        {
            
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioDto, Usuario>();
            Mapper.CreateMap<LaboratorioDto, Laboratorio>();
            Mapper.CreateMap<DisciplinaDto, Disciplina>();
            Mapper.CreateMap<AgendamentoDto, Agendamento>();
        }
    }
}