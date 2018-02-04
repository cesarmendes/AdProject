using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Aplicacao
{
    public interface ICidadeAplicacao : IAplicacao<int, Cidade, ICidadeRepositorio>
    {
        Task<List<Cidade>> FiltrarAsync(int idEstado);
    }
}
