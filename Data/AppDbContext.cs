using Microsoft.EntityFrameworkCore;
using SteveTenadjangMS2D4.Models;

namespace SteveTenadjangMS2D4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produit> Produits => Set<Produit>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>().HasAlternateKey(x => x.Code);
            base.OnModelCreating(modelBuilder);
        }

    }
}
