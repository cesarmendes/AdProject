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
    public class AppRoleClaimConfig : IEntityTypeConfiguration<AppRoleClaim>
    {
        TiposBaseDados Tipos { get; set; }

        public AppRoleClaimConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.ToTable("TBL_PAPEIS_DIREITOS", Tipos.Esquema());
        }
    }
}
