using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Aplicacao
{
    public class CategoriaAplicacao : Aplicacao<int, Categoria, ICategoriaRepositorio>, ICategoriaAplicacao
    {
        public CategoriaAplicacao(ICategoriaRepositorio repositorio)
            : base(repositorio)
        {

        }
    }
}
