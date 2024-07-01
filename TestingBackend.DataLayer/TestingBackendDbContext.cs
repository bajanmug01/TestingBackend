using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestingBackend.DataLayer.Entities;

namespace TestingBackend.DataLayer
{
    public class TestingBackendDbContext : DbContext
    {
        public DbSet<Test> Test { get; set; } = null!;
        protected IHttpContextAccessor HttpContextAccessor { get; } = null!;

        /// <summary>
        /// Constructor used for dependency injection in azure function.
        /// </summary>
        /// <param name="options"></param>
        public TestingBackendDbContext(DbContextOptions<TestingBackendDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Constructor used for dependency injection.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="httpContextAccessor"></param>
        public TestingBackendDbContext(DbContextOptions<TestingBackendDbContext> options, IHttpContextAccessor httpContextAccessor) :
            base(options)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Method that is executed before saving the changes to the database.
        /// Automatically sets 'created' and 'updated' fields for the affected entities
        /// </summary>
        private void OnBeforeSaving()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
            DateTime now = DateTime.UtcNow;
            foreach (EntityEntry entry in entries)
            {
                if (!(entry.Entity is BaseEntity entity))
                    continue;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        // set the updatedOn date to "now"
                        entity.ModifiedOn = now;

                        // mark created* properties as "don't touch", forbid update on a Modify operation
                        entry.Property(nameof(entity.CreatedOn)).IsModified = false;
                        break;
                    case EntityState.Added:
                        // set both modifiedOn and createdOn date to "now"
                        entity.CreatedOn = now;
                        entity.ModifiedOn = now;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupDefaultColumns<Test>(modelBuilder);
        }
        private static void SetupDefaultColumns<TEntity>(ModelBuilder modelBuilder) where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getutcdate())");
            });
        }
    }
}
