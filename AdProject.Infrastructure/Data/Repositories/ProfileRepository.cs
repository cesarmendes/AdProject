using AdProject.Dominio.Entidades;
using AdProject.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.Data.Repositories
{
    public class ProfileRepository : Repository<long, Perfil>, IPerfilRepositorio
    {
        public ProfileRepository(DbContext context)
            : base(context)
        {
        }
    }
}
