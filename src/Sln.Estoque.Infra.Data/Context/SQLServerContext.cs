using Microsoft.EntityFrameworkCore;
using Sln.Estoque.Domain.Entities;

namespace Sln.Estoque.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext() :base() { }

        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                    .HasData(
                    new { Id = 1, Name = "Material"},
                    new { Id = 2, Name = "Ribbon"}
                    );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}