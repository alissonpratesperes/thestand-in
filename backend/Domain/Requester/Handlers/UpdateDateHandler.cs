using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Extensions;
using Domain.Shared.Enumerators;
using Domain.Requester.Commands;
using Domain.Requester.Repositories;

    namespace Domain.Requester.Handlers {
        public class UpdateDateHandler : IHandler<UpdateDateCommand> {
            private readonly IDateRepository _dateRepository;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public UpdateDateHandler(IDateRepository dateRepository, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _dateRepository = dateRepository;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(UpdateDateCommand request, CancellationToken cancellationToken) {
                    var date = await _dateRepository.Read(request.Id);

                        if(date != null) {
                            try {
                                if(date.Status != EStatus.Requested) {
                                    return _commandResult.BadRequest();
                                } else {
                                    date.Update(
                                        name: request.Name,
                                        title: request.Title,
                                        status:
                                            Status.Select(request.Status),
                                        contact: request.Contact,
                                        schedule: request.Schedule,
                                        location: request.Location,
                                        description: request.Description,
                                        displacement:
                                            Displacement.Choose(request.Displacement),
                                        contribution: request.Contribution,
                                        prospectId: request.ProspectId
                                    );

                                        _dateRepository.Update(date);

                                            await _unityOfWork.Commit();

                                                return _commandResult.OK();
                                }
                            } catch (Exception) {
                                _unityOfWork.Rollback();

                                    return _commandResult.InternalServerError();
                            }
                        }

                            return _commandResult.NotFound();
                }
        }
    }