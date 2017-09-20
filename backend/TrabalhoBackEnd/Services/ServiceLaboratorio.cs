using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using AutoMapper;
using TrabalhoBackEnd.Dto;
using TrabalhoBackEnd.Entidades;

namespace TrabalhoBackEnd.Services
{
    public class ServiceLatoratorio
    {
        private Contexto contexo = new Contexto();

        public void Cadastrar(LaboratorioDto laboratorioDto)
        {
            if (String.IsNullOrEmpty(laboratorioDto.Descricao))
            {
                throw new Exception("É necessário uma descrição.");
            }

            var laboratorio = Mapper.Map<LaboratorioDto, Laboratorio>(laboratorioDto);
            contexo.Laboratorios.Add(laboratorio);
            contexo.SaveChanges();
        }

        public List<LaboratorioDto> BuscarTodos()
        {
            var lista = contexo.Laboratorios.Where(x => 1 == 1).ToList();
            return Mapper.Map<List<Laboratorio>, List<LaboratorioDto>>(lista);
        }

        public void Atualizar(LaboratorioDto laboratorioDto)
        {
            var laboratorio = contexo.Laboratorios.Where(x => x.Id == laboratorioDto.Id).FirstOrDefault();

            if (laboratorio == null)
            {
                throw  new ObjectNotFoundException("Disciplina não encontrada.");
            }

            laboratorio.Descricao = laboratorioDto.Descricao;
            laboratorio.NumeroSala = laboratorioDto.NumeroSala;
            laboratorio.Bloco = laboratorioDto.Bloco;
            laboratorio.QtdMaquinas = laboratorio.QtdMaquinas;

            contexo.Laboratorios.AddOrUpdate(laboratorio);
            contexo.SaveChanges();
        }

        public void Deletar(int idLaboratorio)
        {
            var laboratorio = contexo.Laboratorios.Where(x => x.Id == idLaboratorio).FirstOrDefault();

            if (laboratorio == null)
            {
                throw new ObjectNotFoundException("Disciplina não encontrada.");
            }

            contexo.Laboratorios.Remove(laboratorio);
            contexo.SaveChanges();
        }

        public LaboratorioDto ObterLaboratorio(int idLaboratorio)
        {
            var laboratorio = contexo.Laboratorios.Where(x => x.Id == idLaboratorio).FirstOrDefault();

            if (laboratorio == null)
            {
                throw new ObjectNotFoundException("Laboratório não existente.");
            }

            return Mapper.Map<Laboratorio, LaboratorioDto>(laboratorio);
        }




    } 
}