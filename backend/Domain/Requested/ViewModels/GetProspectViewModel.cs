using Domain.Requester.ViewModels;

    namespace Domain.Requested.ViewModels {
        public class GetProspectViewModel {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Goal { get; set; }
            public string Contact { get; set; }
            public string Biography { get; set; }
            public StatusViewModel Status { get; set; }
            public DateTime Birth { get; set; }
            public string Picture { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

                public IList<ListDateViewModel>? Dates { get; set; } = new List<ListDateViewModel>();
        }
    }