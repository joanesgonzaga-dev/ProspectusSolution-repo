using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prospectus.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prospectus.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.SetNull ;

            base.OnModelCreating(builder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataVisita") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataVisita").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataVisita").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Indicador> Indicadores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
