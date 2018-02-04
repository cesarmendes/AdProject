using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using AdProject.Infraestrutura.BancoDados.Contextos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdProject.Infraestrutura.BancoDados.Repositorios
{
    public class CidadeRepositorio : Repositorio<int, Cidade>, ICidadeRepositorio
    {
        public CidadeRepositorio(AdProjectContext context)
            : base(context)
        {
        }

        public async Task<List<Cidade>> Filtrar(int idEstado)
        {
            return await Context.Cidades
                                .Where(cidade => cidade.IdEstado == idEstado)
                                .OrderBy(cidade => cidade.Nome)
                                .AsNoTracking()
                                .ToListAsync();
        }
    }
}
