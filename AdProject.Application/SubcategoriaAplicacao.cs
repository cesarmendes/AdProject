using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Aplicacao
{
    public class SubcategoriaAplicacao : Aplicacao<int, Subcategoria, ISubcategoriaRepositorio>, ISubcategoriaAplicacao
    {
        public SubcategoriaAplicacao(ISubcategoriaRepositorio repositorio)
            : base(repositorio)
        {

        }
    }
}
