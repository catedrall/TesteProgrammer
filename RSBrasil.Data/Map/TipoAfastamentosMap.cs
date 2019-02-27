﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;

namespace RSBrasil.Data.Map
{
    public class TipoAfastamentosMap
    {
        public void Configure(EntityTypeBuilder<TipoAfastamentos> builder)
        {
            builder.ToTable("tipoafastamento");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao");

            builder.Property(c => c.Descricao)
                .HasColumnName("DataInicio");

            builder.Property(c => c.Descricao)
                .HasColumnName("DataFim");

            builder.Property(c => c.Descricao)
                .HasColumnName("Duracao");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");
        }
    }
}