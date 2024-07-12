

using BlogUNAH.API.Database.Entities;
using BlogUNAH.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogUNAH.API.Database
{
    public class BlogUNAHContext : DbContext 

    {
        private readonly IAuthService _authService;

        public BlogUNAHContext(DbContextOptions options,IAuthService authService) : base(options)
        {
            this._authService = authService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Aqui va nuestro codigo - Contexto (Base de Datos)
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {

            }

            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<PostTagEntity> PostTags { get; set; }
    }
}
