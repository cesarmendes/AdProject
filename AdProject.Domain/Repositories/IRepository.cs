using AdProject.Domain.Entities;
using AdProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Domain.Repositories
{
    public interface IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey>
    {
        TEntity Get(TKey id);

        Task<TEntity> GetAsync(TKey id);

        Page<TKey,TEntity> Search();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey id);

        int Commit();

        Task<int> CommitAsync();
    }
}
