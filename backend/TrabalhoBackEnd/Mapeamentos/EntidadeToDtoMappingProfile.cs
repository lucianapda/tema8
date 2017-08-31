using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Entidades;

namespace TrabalhoBackEnd.Mapeamentos
{
    public class EntidadeToDtoMappingProfile : Profile
    {
        public EntidadeToDtoMappingProfile() : base("DomainToViewModelMappings")
        {

        }

        protected override void Configure()
        {
            Mapper.CreateMap<Disciplina, DisciplinaDto>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<Laboratorio, LaboratorioDto>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<Agendamento, AgendamentoDto>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.IdDisciplina, opt => opt.Ignore())
                .ForMember(x => x.IdLaboratorio, opt => opt.Ignore())
                .ForMember(x => x.BlocoLaboratorio, opt => opt.MapFrom(v => v.Laboratorio.Bloco))
                .ForMember(x => x.NumeroSalaLaboratorio, opt => opt.MapFrom(v => v.Laboratorio.NumeroSala))
                .ForMember(x => x.Disciplina, opt => opt.MapFrom(v => v.Disciplina.Descricao));
        }
    }
}