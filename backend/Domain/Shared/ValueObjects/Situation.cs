using Domain.Shared.Entities;

    namespace Domain.Shared.ValueObjects {
        public sealed class Situation : ValueObject {
            public bool Active { get; private set; }
            public bool Available { get; private set; }

                public Situation(bool active, bool available) {
                    this.Active = active;
                    this.Available = available;
                }
        }
    }