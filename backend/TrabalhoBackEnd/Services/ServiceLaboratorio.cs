using System;
using System.Collections.Generic;
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

            contexo.Laboratorios.Add(new Laboratorio() { Descricao = laboratorioDto.Descricao });
            contexo.SaveChanges();
        }

        public LaboratorioDto BuscarTodos()
        {
            var lista = contexo.Laboratorios.Where(x => 1 == 1).ToList().First();
            return Mapper.Map<Laboratorio, LaboratorioDto>(lista);
        }

        public void Atualizar(LaboratorioDto laboratorioDto)
        {
            var laboratorio = contexo.Laboratorios.Where(x => x.Id == laboratorioDto.Id).FirstOrDefault();

            if (laboratorio == null)
            {
                throw  new Exception("Disciplina não encontrada.");
            }

            laboratorio.Descricao = laboratorioDto.Descricao;

            contexo.Laboratorios.AddOrUpdate(laboratorio);
            contexo.SaveChanges();
        }

        public void Deletar(int idLaboratorio)
        {
            var laboratorio = contexo.Laboratorios.Where(x => x.Id == idLaboratorio).FirstOrDefault();

            if (laboratorio == null)
            {
                throw new Exception("Disciplina não encontrada.");
            }

            contexo.Laboratorios.Remove(laboratorio);
            contexo.SaveChanges();
        }

        public LaboratorioDto ObterLaboratorio(int idLaboratorio)
        {
            var laboratorio = contexo.Laboratorios.Where(x => x.Id == idLaboratorio).FirstOrDefault();

            if (laboratorio == null)
            {
                throw new Exception("Laboratório não existente.");
            }

            return Mapper.Map<Laboratorio, LaboratorioDto>(laboratorio);
        }




    } 
}