using AdProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Dominio.Repositorios
{
    public interface ICidadeRepositorio : IRepositorio<int, Cidade>
    {
        Task<List<Cidade>> Filtrar(int idEstado);
    }
}
