using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Aplicacao
{
    public interface ISubcategoriaAplicacao : IAplicacao<int, Subcategoria, ISubcategoriaRepositorio>
    {
    }
}
