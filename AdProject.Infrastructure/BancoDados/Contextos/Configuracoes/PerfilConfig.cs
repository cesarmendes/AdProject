using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class PerfilConfig : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder
                .ToTable("TBL_PEFIS", AdProjectContext.SCHEME_NAME)
                .HasKey(perfil => perfil.Id);

            builder
                .Property(perfil => perfil.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedNever();
        }

        
    }
}
