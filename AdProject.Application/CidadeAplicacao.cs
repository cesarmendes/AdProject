using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Aplicacao
{
    public class CidadeAplicacao : Aplicacao<int, Cidade, ICidadeRepositorio>, ICidadeAplicacao
    {
        public CidadeAplicacao(ICidadeRepositorio repositorio)
            : base(repositorio)
        {
            
        }

        public async Task<List<Cidade>> FiltrarAsync(int idEstado)
        {
            return await Repositorio.Filtrar(idEstado);
        }
    }
}
