using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Shared.Results;
using Domain.Requester.Commands;

    namespace Application.Controllers.Requester {
        [Route("v1/dates")]
        [ApiController]
        public class DateController : ControllerBase {
            private readonly IMediator _mediator;
            public DateController(IMediator mediator) {
                _mediator = mediator;
            }

                [HttpPost]
                public async Task<ICommandResult<Unit>> Create([FromBody] CreateDateCommand command)
                    =>  await _mediator.Send(command);

                [HttpPut]
                public async Task<ICommandResult<Unit>> Update([FromBody] UpdateDateCommand command)
                    =>  await _mediator.Send(command);

                [HttpDelete]
                public async Task<ICommandResult<Unit>> Delete([FromQuery] DeleteDateCommand command)
                    =>  await _mediator.Send(command);
        }
    }