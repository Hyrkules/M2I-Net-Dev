using Articles.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.Api_AvecBDD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Auteur)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuteurId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Utilisateur>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
