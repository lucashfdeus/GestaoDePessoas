using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using LH.GestaoDePessoas.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace LH.GestaoDePessoas.Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected GestaoDePessoasContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(GestaoDePessoasContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            return objReturn;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        //Criando busca paginada SQL.
        public virtual IEnumerable<TEntity> ObterTodosPaginado(int t, int s)
        {
            return DbSet.Take(t).Skip(s).ToList();
        }

        public virtual void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));   
        }

        public int SaveChanges()
        {
           return Db.SaveChanges();
        }
    }
}
