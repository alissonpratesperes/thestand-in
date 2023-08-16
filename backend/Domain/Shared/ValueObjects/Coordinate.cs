using Domain.Shared.Entities;

    namespace Domain.Shared.ValueObjects {
        public sealed class Coordinate : ValueObject {
            public string Latitude { get; private set; }
            public string Longitude { get; private set; }

                public Coordinate(string latitude, string longitude) {
                    this.Latitude = latitude;
                    this.Longitude = longitude;
                }
        }
    }