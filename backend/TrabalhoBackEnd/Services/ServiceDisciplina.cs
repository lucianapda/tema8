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
    public class ServiceDisciplina
    {
        private Contexto contexo = new Contexto();
        public void Cadastrar(DisciplinaDto disciplinaDto)
        {
            if (String.IsNullOrEmpty(disciplinaDto.Descricao))
            {
                throw new Exception("É necessário uma descrição.");
            }
            var disciplina = Mapper.Map<DisciplinaDto, Disciplina>(disciplinaDto);
            contexo.Disciplinas.Add(disciplina);
            contexo.SaveChanges();
        }

        public DisciplinaDto BuscarTodos()
        {
            var lista = contexo.Disciplinas.Where(x => 1 == 1).ToList().First();
            return Mapper.Map<Disciplina, DisciplinaDto>(lista);
        }

        public void Atualizar(DisciplinaDto disciplinaDto)
        {
            var disciplina = contexo.Disciplinas.Where(x => x.Id == disciplinaDto.Id).FirstOrDefault();

            if (disciplina == null)
            {
                throw  new ObjectNotFoundException("Disciplina não encontrada.");
            }

            disciplina.Descricao = disciplinaDto.Descricao;
            disciplina.Curso = disciplinaDto.Curso;
            contexo.Disciplinas.AddOrUpdate(disciplina);
            contexo.SaveChanges();
        }

        public void Deletar(int idDisciplina)
        {
            var disciplina = contexo.Disciplinas.Where(x => x.Id == idDisciplina).FirstOrDefault();

            if (disciplina == null)
            {
                throw new ObjectNotFoundException("Disciplina não encontrada.");
            }

            contexo.Disciplinas.Remove(disciplina);
            contexo.SaveChanges();
        }


        public DisciplinaDto Obter(int idDisciplina)
        {
            var disciplina = contexo.Disciplinas.Where(x => x.Id == idDisciplina).FirstOrDefault();

            if (disciplina == null)
            {
                throw new ObjectNotFoundException("Disciplina não encontrada.");
            }

            return Mapper.Map<Disciplina, DisciplinaDto>(disciplina);
        }

    } 
}