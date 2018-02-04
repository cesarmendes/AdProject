using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.Identity;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        TiposBaseDados Tipos { get; set; }

        public AppUserRoleConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }

        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("TBL_USUARIO_PAPEIS", Tipos.Esquema());
        }
    }
}
