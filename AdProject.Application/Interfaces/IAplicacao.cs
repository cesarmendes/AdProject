using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Aplicacao
{
    public interface IAplicacao<TChave, TEntidade, TRepositorio>
        where TChave : struct
        where TEntidade : Entidade<TChave>
        where TRepositorio : IRepositorio<TChave, TEntidade>
    {
        List<TEntidade> Todos();
        Task<List<TEntidade>> TodosAsync();
    }
}
