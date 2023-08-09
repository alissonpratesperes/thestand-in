using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Shared.Results;
using Domain.Requested.Commands;

    namespace Application.Controllers.Requested {
        [Route("v1/prospects")]
        [ApiController]
        public class ProspectController : ControllerBase {
            private readonly IMediator _mediator;
            public ProspectController(IMediator mediator) {
                _mediator = mediator;
            }

                [HttpPost]
                public async Task<ICommandResult<Unit>> Create([FromBody] CreateProspectCommand command)
                    =>  await _mediator.Send(command);

                [HttpPut]
                public async Task<ICommandResult<Unit>> Update([FromBody] UpdateProspectCommand command)
                    =>  await _mediator.Send(command);

                [HttpDelete]
                public async Task<ICommandResult<Unit>> Delete([FromQuery] DeleteProspectCommand command)
                    =>  await _mediator.Send(command);
        }
    }