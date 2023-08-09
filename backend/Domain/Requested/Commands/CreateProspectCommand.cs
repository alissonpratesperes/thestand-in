using MediatR;

using Domain.Shared.Results;
using Domain.Shared.Commands;

    namespace Domain.Requested.Commands {
        public class CreateProspectCommand : ICommand<ICommandResult<Unit>> {
            public string Name { get; set; }
            public decimal Goal { get; set; }
            public bool Active { get; set; }
            public string Contact { get; set; }
            public string Biography { get; set; }
            public bool Available { get; set; }
            public DateOnly Birth { get; set; }
            public string Picture { get; set; }
        }
    }