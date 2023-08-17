using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Shared.Results;
using Domain.Requester.Commands;
using Domain.Requester.Actions.Commands;

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

                [HttpPut("accept")]
                public async Task<ICommandResult<Unit>> Accept([FromQuery] AcceptDateCommand action)
                    =>  await _mediator.Send(action);

                [HttpPut("finish")]
                public async Task<ICommandResult<Unit>> Finish([FromQuery] FinishDateCommand action)
                    =>  await _mediator.Send(action);
        }
    }