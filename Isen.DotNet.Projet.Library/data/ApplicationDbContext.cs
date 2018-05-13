using Isen.DotNet.Projet.Library.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Isen.DotNet.Projet.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        // 1 - Préciser les DbSet
        public DbSet<PI> PICollection { get; set; }
        public DbSet<Adresse> AdresseCollection { get; set; }
        public DbSet<Categorie> CategorieCollection { get; set; }
        public DbSet<Commune> CommuneCollection { get; set; }
        public DbSet<Departement> DepartementCollection { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 2 - Configurer les mappings tables / classes
            

            builder.Entity<Adresse>()
                .ToTable("Adresse")
                .HasOne(a => a.Commune)
                .WithMany(c => c.AdresseCollection)
                .OnDelete(DeleteBehavior.SetNull);
                
            builder.Entity<Categorie>()
                .ToTable("Categorie");

            builder.Entity<Commune>()
                .ToTable("Commune")
                .HasMany(c => c.AdresseCollection)
                .WithOne(a => a.Commune)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Departement>()
                .ToTable("Departement");

            builder.Entity<PI>()
                .ToTable("PI")
                .HasOne(p => p.Adresse)
                .WithMany(a => a.PICollection)
                .HasForeignKey(p => p.AdresseID);
             builder.Entity<PI>()
                .ToTable("PI")
                .HasOne(p => p.Categorie)
                .WithMany(a => a.PICollection)
                .HasForeignKey(p => p.CategorieID);
        }
    }
}