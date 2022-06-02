using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prospectus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);

            builder.Property(e => e.Complemento)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasColumnName("Bairro");

            builder.Property(e => e.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .HasMaxLength(8);

            builder.Property(e => e.UF)
                .IsRequired()
                .HasColumnType("varchar(2)")
                .HasMaxLength(2);

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);

            builder.HasOne(e => e.Prospect)
                .WithOne(p => p.Endereco)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
