using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prospectus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Mappings
{
    public class IndicadorMapping : IEntityTypeConfiguration<Indicador>
    {
        public void Configure(EntityTypeBuilder<Indicador> builder)
        {
            builder.ToTable("Indicadores");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);

            builder.HasMany(i => i.Prospects)
                .WithOne(p => p.Indicador)
                .HasForeignKey(p => p.IndicadorId);
                //.OnDelete(DeleteBehavior.Restrict);

            //builder.Property(i => i.Prospects);

            //builder.HasMany(i => i.Prospects)
            //    .WithOne(p => p.Indicador)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
