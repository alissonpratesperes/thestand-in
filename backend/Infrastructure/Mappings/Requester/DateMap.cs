using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Requested.Models;
using Domain.Requester.Models;
using Infrastructure.Shared.Mappings;

    namespace Infrastructure.Mappings.Requester {
        public class DateMap : EntityMap<Date> {
            protected override void ConfigureMap(EntityTypeBuilder<Date> builder) {
                builder.Property(date => date.Name);
                builder.Property(date => date.Title);
                builder.Property(date => date.Status);
                builder.Property(date => date.Contact);
                builder.Property(date => date.Schedule);
                builder.Property(date => date.Latitude);
                builder.Property(date => date.Longitude);
                builder.Property(date => date.Description);
                builder.Property(date => date.Displacement);
                builder.Property(date => date.Contribution);

                builder.HasOne(date => date.Prospect).WithMany(prospect => prospect.Dates).HasForeignKey(date => date.ProspectId);
            }
        }
    }