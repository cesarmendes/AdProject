using AdProject.Dominio.Entidades;
using AdProject.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Dominio.Repositorios
{
    public interface IRepositorio<TKey, TEntity>
        where TKey : struct
        where TEntity : Entidade<TKey>
    {
        TEntity Obter(TKey id);

        Task<TEntity> ObterAsync(TKey id);

        Page<TKey,TEntity> Filtrar();

        void Inserir(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);

        void Remover(TKey id);

        int Salvar();

        Task<int> SalvarAsync();
    }
}
