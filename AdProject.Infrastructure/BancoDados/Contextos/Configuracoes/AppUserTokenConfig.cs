using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;
using AdProject.Infraestrutura.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class AppUserTokenConfig : IEntityTypeConfiguration<AppUserToken>
    {
        TiposBaseDados Tipos { get; set; }

        public AppUserTokenConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }

        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            builder.ToTable("TBL_USUARIO_TOKENS", Tipos.Esquema());
        }
    }
}
