using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using AdProject.Dominio.ValueObjects;
using AdProject.Infraestrutura.BancoDados.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Infraestrutura.BancoDados.Repositorios
{
    public abstract class Repositorio<TKey, TEntity> : IRepositorio<TKey, TEntity>
        where TKey : struct
        where TEntity : Entidade<TKey>
    {
        public AdProjectContext Context { get; private set; }

        public Repositorio(AdProjectContext context)
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

        public async Task<int> SalvarAsync()
        {
            return await this.Context.SaveChangesAsync();
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

        public List<TEntity> Todos()
        {
            return this.Context.Set<TEntity>().AsNoTracking().ToList();
        }

        public async Task<List<TEntity>> TodosAsync()
        {
            return await this.Context.Set<TEntity>().AsNoTracking().ToListAsync();
        }
    }
}
