using Domain.Shared.Enumerators;
using Domain.Requested.ViewModels;

    namespace Domain.Requester.ViewModels {
        public class GetDateViewModel {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public EStatus Status { get; set; }
            public string Contact { get; set; }
            public DateTime Schedule { get; set; }
            public CoordinateViewModel Location { get; set; }
            public string Description { get; set; }
            public EDisplacement Displacement { get; set; }
            public decimal Contribution { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

                public ListProspectViewModel Prospect { get; set; }
        }
    }