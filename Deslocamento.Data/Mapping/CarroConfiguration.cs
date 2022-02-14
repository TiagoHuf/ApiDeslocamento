using ApiDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Data.Mapping
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("Carro");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Placa).IsRequired().HasColumnName("Placa").HasMaxLength(200);

            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(400);

        }
    }
}