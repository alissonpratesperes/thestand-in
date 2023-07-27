using Microsoft.EntityFrameworkCore;

using Domain.Shared.Entities;
using Domain.Requested.Models;
using Domain.Requester.Models;
using Infrastructure.Mappings.Requested;
using Infrastructure.Mappings.Requester;

    namespace Infrastructure.Contexts {
        public class Context : DbContext {
            public Context(DbContextOptions<Context> options) : base(options) {}

                public DbSet<Prospect> Prospects { get; set; }
                public DbSet<Date> Dates { get; set; }

                    protected override void OnModelCreating(ModelBuilder builder) {
                        builder.ApplyConfiguration(new ProspectMap());
                        builder.ApplyConfiguration(new DateMap());
                    }

                        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken)) {
                            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

                                AddedEntities.ForEach(E => {
                                    if (typeof(Entity).IsInstanceOfType(E.Entity) && (
                                        E.Property("CreatedAt").CurrentValue == null
                                        || ((DateTime)E.Property("CreatedAt").CurrentValue).CompareTo(DateTime.MinValue) == 0
                                    )) {
                                        E.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                                    }
                                });

                            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

                                EditedEntities.ForEach(E => {
                                    if (typeof(Entity).IsInstanceOfType(E.Entity) && (
                                        E.Property("UpdatedAt").CurrentValue == null
                                        || ((DateTime)E.Property("UpdatedAt").CurrentValue).CompareTo(DateTime.MinValue) == 0
                                        || ((DateTime)E.Property("UpdatedAt").CurrentValue) < DateTime.UtcNow
                                    )) {
                                        E.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                                    }
                                });

                                    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                        }
        }
    }