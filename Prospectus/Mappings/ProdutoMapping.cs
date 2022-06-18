using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prospectus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(99)")
                .HasMaxLength(99);

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(220)")
                .HasMaxLength(220);

            builder.Property(p => p.Imagem)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Unidade)
                .IsRequired()
                .HasColumnName("Unidade")
                .HasColumnType("varchar(3)")
                .HasMaxLength(3);

            builder.Property(p => p.NCM)
                .IsRequired()
                .HasColumnName("NCM")
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                ;

            builder.Property(p => p.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro")
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd()
                .IsRequired();

           

        }
    }
}
