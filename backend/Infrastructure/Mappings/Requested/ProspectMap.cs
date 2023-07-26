using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Requested.Models;
using Infrastructure.Shared.Mappings;

    namespace Infrastructure.Mappings.Requested {
        public class ProspectMap : EntityMap<Prospect> {
            protected override void ConfigureMap(EntityTypeBuilder<Prospect> builder) {
                builder.Property(p => p.Name);
                builder.Property(p => p.Goal);
                builder.Property(p => p.Active);
                builder.Property(p => p.Contact);
                builder.Property(p => p.Biography);
                builder.Property(p => p.Available);
                builder.Property(p => p.Birth);
                builder.Property(p => p.Picture);
            }
        }
    }