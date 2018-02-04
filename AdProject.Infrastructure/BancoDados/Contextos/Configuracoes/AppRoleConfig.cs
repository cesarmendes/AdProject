using AdProject.Infraestrutura.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        TiposBaseDados Tipos { get; set; }

        public AppRoleConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }

        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("TBL_PAPEIS", Tipos.Esquema());
        }
    }
}
