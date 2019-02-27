﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RSBrasil.Model.Interface.Data
{
    public interface IRepositorioBase<T> where T : class
    {
        List<T> Listar();
        T RetornaObjeto(T entity);
        T PesquisarPorId(long id);
        T BuscaQualquerParametro(Expression<Func<T, bool>> predicate);
        List<T> BuscaTodosQualquerParametro(Expression<Func<T, bool>> predicate);
        T Inserir(T entity);
        void InserirVarios(List<T> entities);
        void Atualizar(T entity);
        void AtualizarVarios(List<T> entities);
        void Excluir(T entity);
        void ExcluirVarios(List<T> entities);
        IQueryable<T> ConsultaJoin(T entity);
    }
}
