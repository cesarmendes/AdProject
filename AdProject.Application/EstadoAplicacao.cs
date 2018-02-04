using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Aplicacao
{
    public class EstadoAplicacao : Aplicacao<int, Estado, IEstadoRepositorio>, IEstadoAplicacao
    {
        public EstadoAplicacao(IEstadoRepositorio repositorio)
            : base(repositorio)
        {

        }
    }
}
