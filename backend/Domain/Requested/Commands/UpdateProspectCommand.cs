namespace Domain.Requested.Commands {
    public class UpdateProspectCommand : CreateProspectCommand {
        public Guid Id { get; set; }
    }
}