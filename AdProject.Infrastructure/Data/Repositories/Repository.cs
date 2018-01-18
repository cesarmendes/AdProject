using AdProject.Domain.Entities;
using AdProject.Domain.Repositories;
using AdProject.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Infrastructure.Data.Repositories
{
    public abstract class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey>
    {
        public DbContext Context { get; private set; }

        public Repository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Repository context reference cannot be null");

            this.Context = context;
        }

        public TEntity Get(TKey id)
        {
            return this.Context.Find<TEntity>(id);
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return this.Context.FindAsync<TEntity>(id);
        }

        public void Insert(TEntity entity)
        {
            this.Context.Add<TEntity>(entity);
        }

        public void Update(TEntity entity)
        {
            this.Context.Update<TEntity>(entity);
        }

        public void Delete(TEntity entity)
        {
            this.Context.Remove<TEntity>(entity);
        }

        public void Delete(TKey id)
        {
            var entity = default(TEntity);
            entity.Id = id;

            this.Context.Remove<TEntity>(entity);
        }

        public int Commit()
        {
            return this.Context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return this.Context.SaveChangesAsync();
        }

        public Page<TKey, TEntity> Search()
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
