using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using AdProject.Dominio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Infraestrutura.Data.Repositories
{
    public abstract class Repository<TKey, TEntity> : IRepositorio<TKey, TEntity>
        where TKey : struct
        where TEntity : Entidade<TKey>
    {
        public DbContext Context { get; private set; }

        public Repository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Repository context reference cannot be null");

            this.Context = context;
        }

        public TEntity Obter(TKey id)
        {
            return this.Context.Find<TEntity>(id);
        }

        public Task<TEntity> ObterAsync(TKey id)
        {
            return this.Context.FindAsync<TEntity>(id);
        }

        public void Inserir(TEntity entity)
        {
            this.Context.Add<TEntity>(entity);
        }

        public void Atualizar(TEntity entity)
        {
            this.Context.Update<TEntity>(entity);
        }

        public void Remover(TEntity entity)
        {
            this.Context.Remove<TEntity>(entity);
        }

        public void Remover(TKey id)
        {
            var entity = default(TEntity);
            entity.Id = id;

            this.Context.Remove<TEntity>(entity);
        }

        public int Salvar()
        {
            return this.Context.SaveChanges();
        }

        public Task<int> SalvarAsync()
        {
            return this.Context.SaveChangesAsync();
        }

        public Page<TKey, TEntity> Filtrar()
        {
            throw new NotImplementedException();
        }

        protected Page<TKey, TEntity> Paging(int actual, IQueryable<TEntity> query)
        {
            query.LongCount();

            query.Skip(10).Take(10).ToListAsync();

                      throw new NotImplementedException();
        }
    }
}
