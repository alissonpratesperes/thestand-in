using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Shared.Entities;

    namespace Infrastructure.Shared.Mappings {
        public abstract class EntityMap<T>: IEntityTypeConfiguration<T> where T : Entity {
            public void Configure(EntityTypeBuilder<T> builder) {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.CreatedAt);
                builder.Property(x => x.UpdatedAt);

                    ConfigureMap(builder);
            }

                protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);
        }
    }