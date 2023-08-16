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
                builder.Property(date => date.Description);
                builder.Property(date => date.Displacement);
                builder.Property(date => date.Contribution);

                builder.OwnsOne(date => date.Location, coordinate => {
                    coordinate.Property(position => position.Latitude);
                    coordinate.Property(position => position.Longitude);
                });

                builder.HasOne(date => date.Prospect).WithMany(prospect => prospect.Dates).HasForeignKey(date => date.ProspectId);
            }
        }
    }