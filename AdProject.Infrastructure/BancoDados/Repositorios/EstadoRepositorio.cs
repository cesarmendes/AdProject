﻿using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using AdProject.Infraestrutura.BancoDados.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Repositorios
{
    public class EstadoRepositorio : Repositorio<int, Estado>, IEstadoRepositorio
    {
        public EstadoRepositorio(AdProjectContext context)
          : base(context)
        {
        }
    }
}
