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
    public class AppUserLoginConfig : IEntityTypeConfiguration<AppUserLogin>
    {
        TiposBaseDados Tipos { get; set; }

        public AppUserLoginConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }

        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.ToTable("TBL_USUARIO_LOGINS", Tipos.Esquema());
        }
    }
}
