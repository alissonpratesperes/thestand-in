using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Shared.Results;
using Domain.Shared.Returns;
using Domain.Shared.Paginations;
using Domain.Requested.Queries;
using Domain.Requested.Commands;
using Domain.Requested.ViewModels;

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

                [HttpGet]
                public async Task<Return<Pagination<ListProspectViewModel>>> List([FromQuery] ListProspectQuery query)
                    =>  await _mediator.Send(query);

                [HttpGet("{id}")]
                public async Task<Return<GetProspectViewModel>> Get([FromRoute] GetProspectQuery query)
                    =>  await _mediator.Send(query);
        }
    }