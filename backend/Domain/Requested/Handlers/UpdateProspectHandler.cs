using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Enumerators;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class UpdateProspectHandler : IHandler<UpdateProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public UpdateProspectHandler(IProspectRepository prospectRepository, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _prospectRepository = prospectRepository;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(UpdateProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = await _prospectRepository.Read(request.Id);

                        if(prospect != null) {
                            try {
                                if(prospect.Dates.Count(date => date.Status == EStatus.Requested) > 0) {
                                    return _commandResult.BadRequest();
                                } else {
                                    prospect.Update(
                                        name: request.Name,
                                        goal: request.Goal,
                                        active: request.Active,
                                        contact: request.Contact,
                                        biography: request.Biography,
                                        available: request.Available,
                                        birth: request.Birth,
                                        picture: request.Picture
                                    );

                                        _prospectRepository.Update(prospect);

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