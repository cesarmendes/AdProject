using AdProject.Dominio.Entidades;
using AdProject.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Dominio.Repositorios
{
    public interface IRepositorio<TChave, TEntidade>
        where TChave : struct
        where TEntidade : Entidade<TChave>
    {
        List<TEntidade> Todos();

        Task<List<TEntidade>> TodosAsync();

        TEntidade Obter(TChave id);

        Task<TEntidade> ObterAsync(TChave id);

        Page<TChave,TEntidade> Filtrar();

        void Inserir(TEntidade entity);

        void Atualizar(TEntidade entity);

        void Remover(TEntidade entity);

        void Remover(TChave id);

        int Salvar();

        Task<int> SalvarAsync();
    }
}
