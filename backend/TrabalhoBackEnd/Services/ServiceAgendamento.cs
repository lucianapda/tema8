using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Entidades;
using TrabalhoBackEnd.Enumeradores;
using AutoMapper;

namespace TrabalhoBackEnd.Services
{
    public class ServiceAgendamento
    {
        private Contexto contexo = new Contexto();

        public void Cadastrar(AgendamentoDto agendamentoDto)
        {
            var laboratorio = contexo.Laboratorios.Where(x => x.Id == agendamentoDto.IdLaboratorio).FirstOrDefault();

            if (laboratorio == null)
            {
                throw new Exception("Laboratório não cadastrado.");
            }

            var disciplina = contexo.Disciplinas.Where(x => x.Id == agendamentoDto.IdDisciplina).FirstOrDefault();

            if (disciplina == null)
            {
                throw new Exception("Disciplina não cadastrada.");
            }

            var horarioAgendamento = contexo.Agendamentos
                .Where(x => (x.HorarioInicial <= agendamentoDto.HorarioInicial &&
                            x.HorarioFinal >= agendamentoDto.HorarioInicial) ||
                            (x.HorarioInicial <= agendamentoDto.HorarioFinal &&
                             x.HorarioFinal >= agendamentoDto.HorarioFinal))
                .FirstOrDefault();

            if (horarioAgendamento != null)
            {
                throw new Exception("Horário já reservado.");
            }

            var agendamento = new Agendamento()
            {
                Disciplina = disciplina,
                Laboratorio = laboratorio,
                HorarioInicial = agendamentoDto.HorarioInicial,
                HorarioFinal = agendamentoDto.HorarioFinal,
                Status = StatusAgendamento.Aberto
            };

            contexo.Agendamentos.AddOrUpdate(agendamento);
            contexo.SaveChanges();
        }

        public void AlterarStatusLaboratorio(AgendamentoDto agendamentoDto, StatusAgendamento status)
        {
            var agendamento = contexo.Agendamentos.AsQueryable();

            if (agendamentoDto.Id != 0)
            {
                agendamento = agendamento.Where(x => x.Id == agendamentoDto.Id);
            }

            if (agendamentoDto.IdDisciplina != 0)
            {
                agendamento = agendamento.Where(x => x.Disciplina.Id == agendamentoDto.IdDisciplina);
            }

            if (agendamentoDto.IdLaboratorio != 0)
            {
                agendamento = agendamento.Where(x => x.Laboratorio.Id == agendamentoDto.IdLaboratorio);
            }

            if (agendamentoDto.HorarioInicial != null)
            {
                agendamento = agendamento.Where(x => x.HorarioInicial == agendamentoDto.HorarioInicial);
            }

            if (agendamentoDto.HorarioFinal != null)
            {
                agendamento = agendamento.Where(x => x.HorarioFinal == agendamentoDto.HorarioFinal);
            }

            var result = agendamento.ToList();

            if (result.Count > 1)
            {
                throw new Exception("Inclua mais informações, para que seja liberado somente um horário.");
            }

            var horario = result.First();

            if (horario.HorarioFinal < DateTime.Now)
            {
                throw new Exception("Horárío já finalizado.");
            }

            if (horario.HorarioInicial < DateTime.Now)
            {
                throw new Exception("Horário em andamento.");
            }

            horario.Status = status;
            contexo.Agendamentos.AddOrUpdate(horario);
            contexo.SaveChanges();
        }

        public List<AgendamentoDto> BuscarTodosAgendamento()
        {
            try
            {
                var retorno = contexo.Agendamentos.Where(x => x.HorarioInicial > DateTime.Now)
                    .OrderBy(x => x.HorarioInicial).ToList();

                return Mapper.Map<List<Agendamento>, List<AgendamentoDto>>(retorno);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível buscar todos os agendamentos.");
            }
        }

        public List<AgendamentoDto> BuscarAgendamentos(AgendamentoDto agendamento)
        {
            try
            {
                if (agendamento.NumeroSalaLaboratorio > 0)
                {
                    if (String.IsNullOrEmpty(agendamento.BlocoLaboratorio))
                    {
                        throw new ArgumentNullException("É necessário o bloco da sala para realizar a consulta corretamente.");
                    }
                }
                var consulta = contexo.Agendamentos.Where(x => x.Status == StatusAgendamento.Aberto);

                if (agendamento.IdDisciplina > 0)
                {
                    consulta = consulta.Where(x => x.Disciplina.Id == agendamento.IdDisciplina);
                }

                if (agendamento.IdLaboratorio > 0)
                {
                    consulta = consulta.Where(x => x.Laboratorio.Id == agendamento.IdLaboratorio);
                }

                if (!String.IsNullOrEmpty(agendamento.BlocoLaboratorio))
                {
                    consulta = consulta.Where(x => x.Laboratorio.Bloco == agendamento.BlocoLaboratorio);
                }

                if (agendamento.NumeroSalaLaboratorio > 0)
                {
                    consulta = consulta.Where(x => x.Laboratorio.NumeroSala == agendamento.NumeroSalaLaboratorio);
                }

                return Mapper.Map<List<Agendamento>, List<AgendamentoDto>>(consulta.ToList());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}