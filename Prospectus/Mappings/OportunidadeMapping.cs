using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prospectus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Mappings
{
    public class OportunidadeMapping : IEntityTypeConfiguration<Oportunidade>
    {
        public void Configure(EntityTypeBuilder<Oportunidade> builder)
        {
            builder.ToTable("Oportunidades");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id);
            builder.Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(o => o.Descricao)
                .HasColumnType("varchar(250)");

            builder.HasMany(o => o.Prospects)
                .WithOne(p => p.Oportunidade)
                .HasForeignKey(p => p.OportunidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Produtos)
                .WithOne(p => p.Oportunidade)
                .HasForeignKey(p => p.OportunidadeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
