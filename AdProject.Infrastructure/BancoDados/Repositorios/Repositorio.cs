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
    public abstract class Repositorio<TChave, TEntidade> : IRepositorio<TChave, TEntidade>
        where TChave : struct
        where TEntidade : Entidade<TChave>
    {
        public AdProjectContext Context { get; private set; }

        public Repositorio(AdProjectContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Repository context reference cannot be null");

            this.Context = context;
        }

        public TEntidade Obter(TChave id)
        {
            return this.Context.Find<TEntidade>(id);
        }

        public Task<TEntidade> ObterAsync(TChave id)
        {
            return this.Context.FindAsync<TEntidade>(id);
        }

        public void Inserir(TEntidade entity)
        {
            this.Context.Add<TEntidade>(entity);
        }

        public void Atualizar(TEntidade entity)
        {
            this.Context.Update<TEntidade>(entity);
        }

        public void Remover(TEntidade entity)
        {
            this.Context.Remove<TEntidade>(entity);
        }

        public void Remover(TChave id)
        {
            var entity = default(TEntidade);
            entity.Id = id;

            this.Context.Remove<TEntidade>(entity);
        }

        public int Salvar()
        {
            return this.Context.SaveChanges();
        }

        public async Task<int> SalvarAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

        public Page<TChave, TEntidade> Filtrar()
        {
            throw new NotImplementedException();
        }

        protected Page<TChave, TEntidade> Paging(int actual, IQueryable<TEntidade> query)
        {
            query.LongCount();

            query.Skip(10).Take(10).ToListAsync();

                      throw new NotImplementedException();
        }

        public List<TEntidade> Todos()
        {
            return this.Context.Set<TEntidade>().AsNoTracking().ToList();
        }

        public async Task<List<TEntidade>> TodosAsync()
        {
            return await this.Context.Set<TEntidade>().AsNoTracking().ToListAsync();
        }
    }
}
