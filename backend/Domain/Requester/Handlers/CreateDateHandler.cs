using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Extensions;
using Domain.Requester.Models;
using Domain.Requester.Commands;
using Domain.Requester.Repositories;

    namespace Domain.Requester.Handlers {
        public class CreateDateHandler : IHandler<CreateDateCommand> {
            private readonly IDateRepository _dateRepository;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public CreateDateHandler(IDateRepository dateRepository, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _dateRepository = dateRepository;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(CreateDateCommand request, CancellationToken cancellationToken) {
                    try {
                        var date = new Date(
                            name: request.Name,
                            title: request.Title,
                            status: request.Status,
                            contact: request.Contact,
                            schedule: request.Schedule,
                            location: request.Location,
                            description: request.Description,
                            displacement:
                                Displacement.Choose(request.Displacement),
                            contribution: request.Contribution,
                            prospectId: request.ProspectId
                        );

                            await _dateRepository.Create(date);
                            await _unityOfWork.Commit();

                                return _commandResult.Created();
                    } catch (Exception) {
                        _unityOfWork.Rollback();

                            return _commandResult.InternalServerError();
                    }
                }
        }
    }