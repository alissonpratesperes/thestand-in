using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Requested.Models;
using Domain.Requester.Models;
using Infrastructure.Shared.Mappings;

    namespace Infrastructure.Mappings.Requested {
        public class ProspectMap : EntityMap<Prospect> {
            protected override void ConfigureMap(EntityTypeBuilder<Prospect> builder) {
                builder.Property(prospect => prospect.Name);
                builder.Property(prospect => prospect.Goal);
                builder.Property(prospect => prospect.Active);
                builder.Property(prospect => prospect.Contact);
                builder.Property(prospect => prospect.Biography);
                builder.Property(prospect => prospect.Available);
                builder.Property(prospect => prospect.Birth);
                builder.Property(prospect => prospect.Picture);

                builder.HasMany(prospect => prospect.Dates).WithOne(date => date.Prospect).HasForeignKey(date => date.ProspectId);
            }
        }
    }