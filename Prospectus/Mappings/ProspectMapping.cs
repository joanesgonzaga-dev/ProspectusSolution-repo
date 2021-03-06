
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prospectus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Mappings
{
    public class ProspectMapping : IEntityTypeConfiguration<Prospect>
    {
        public void Configure(EntityTypeBuilder<Prospect> builder)
        {
            builder.ToTable("Prospects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.Property(p => p.PessoaContato)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasColumnName("PessoaContato");

            builder.Property(p => p.DataVisita)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(p => p.Ramo)
                .IsRequired()
                .HasColumnType("varchar(120)")
                .HasColumnName("Ramo");

            

            builder.Property(p => p.Recepcao)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Recepcao");

            builder.Property(p => p.Cenario)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("Cenario");

            builder.Property(p => p.SatisfacaoCenario)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("SatisfacaoCenario");

            builder.Property(p => p.Observacoes)
                .HasColumnType("nvarchar(200)")
                .HasColumnName("Observacoes");

            builder.Property(p => p.DataRetorno)
                .HasColumnType("datetime")
                .HasColumnName("DataRetorno")
                //.HasDefaultValueSql("getdate()")
                .IsRequired();


            builder.Property(p => p.IndicadorId)
                .IsRequired()
                .HasColumnName("IndicadorId");

            

            /*
            builder.HasOne(p => p.Indicador)
                .WithMany(i => i.Prospects)
                .HasForeignKey(p => p.IndicadorId)
                .OnDelete(DeleteBehavior.Restrict);
            */

            builder.HasOne(p => p.Endereco)
                .WithOne(e => e.Prospect)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
