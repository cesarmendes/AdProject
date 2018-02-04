using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using AdProject.Infraestrutura.BancoDados.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Repositorios
{
    public class CategoriaRepositorio : Repositorio<int, Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(AdProjectContext context)
            : base(context)
        {
        }
    }
}
