using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Aplicacao
{
    public class Aplicacao<TChave, TEntidade, TRepositorio> : IAplicacao<TChave, TEntidade, TRepositorio>
        where TChave : struct
        where TEntidade : Entidade<TChave>
        where TRepositorio : IRepositorio<TChave, TEntidade>
    {
        protected TRepositorio Repositorio { get; set; }

        public Aplicacao(TRepositorio repositorio)
        {
            if (repositorio == null)
                throw new ArgumentNullException("O repositório para iniciar a camada de aplicação não pode ser nulo");

            this.Repositorio = repositorio;
        }

        public List<TEntidade> Todos()
        {
            return Repositorio.Todos();
        }

        public Task<List<TEntidade>> TodosAsync()
        {
            return Repositorio.TodosAsync();
        }
    }
}
