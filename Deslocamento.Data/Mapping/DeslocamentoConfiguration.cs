using ApiDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Data.Mapping
{
    public class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamentos>
    {

        public void Configure(EntityTypeBuilder<Deslocamentos> builder)
        {
            builder.ToTable("Deslocamento");

            builder.HasKey(p => p.Id);

            builder.HasOne(e => e.Carro).WithMany(d => d.Deslocamentos).HasForeignKey(e => e.CarroId).HasConstraintName("FK_Carro_Deslocamento_CarroId");

            builder.HasOne(e => e.Cliente).WithMany(d => d.Deslocamentos).HasForeignKey(e => e.ClienteId).HasConstraintName("FK_Cliente_Deslocamento_ClienteId");

            builder.HasOne(e => e.Condutor).WithMany(d => d.Deslocamentos).HasForeignKey(e => e.CarroId).HasConstraintName("FK_Condutor_Deslocamento_CondutorId");

            builder.Property(p => p.DataHoraInicio).IsRequired().HasColumnName("DataHoraInicio").HasColumnType("datetime");

            builder.Property(q => q.QuilometragemInicial).IsRequired().HasColumnName("QuilometragemInicial").HasColumnType("decimal");

            builder.Property(p => p.DataHorarioFim).HasColumnName("DataHoraFim").HasColumnType("datetime");

            builder.Property(p => p.Observacao).IsRequired().HasColumnName("Observacao").HasMaxLength(400);

            builder.Property(q => q.QuilometragemFinal).HasColumnName("QuilometragemFinal").HasColumnType("decimal");
        }
    }
}
