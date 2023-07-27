using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Requester.Models;
using Infrastructure.Shared.Mappings;

    namespace Infrastructure.Mappings.Requester {
        public class DateMap : EntityMap<Date> {
            protected override void ConfigureMap(EntityTypeBuilder<Date> builder) {
                builder.Property(d => d.Name);
                builder.Property(d => d.Title);
                builder.Property(d => d.Status);
                builder.Property(d => d.Contact);
                builder.Property(d => d.Schedule);
                builder.Property(d => d.Latitude);
                builder.Property(d => d.Longitude);
                builder.Property(d => d.Description);
                builder.Property(d => d.Displacement);
                builder.Property(d => d.Contribution);
            }
        }
    }