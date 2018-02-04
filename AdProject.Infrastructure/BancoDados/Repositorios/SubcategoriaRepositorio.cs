using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using AdProject.Infraestrutura.BancoDados.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Repositorios
{
    public class SubcategoriaRepositorio : Repositorio<int, Subcategoria>, ISubcategoriaRepositorio
    {
        public SubcategoriaRepositorio(AdProjectContext context)
            : base(context)
        {
        }
    }
}
