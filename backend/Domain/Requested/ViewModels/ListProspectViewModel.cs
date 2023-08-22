namespace Domain.Requested.ViewModels {
    public class ListProspectViewModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Goal { get; set; }
        public bool Status_Active { get; set; }
        public string Contact { get; set; }
        public string Biography { get; set; }
        public bool Status_Available { get; set; }
        public DateTime Birth { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}