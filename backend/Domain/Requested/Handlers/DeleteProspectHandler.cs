using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class DeleteProspectHandler : IHandler<DeleteProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public DeleteProspectHandler(IProspectRepository prospectRepository, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _prospectRepository = prospectRepository;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(DeleteProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = await _prospectRepository.Read(request.Id);

                        if(prospect != null) {
                            try {
                                if(prospect.Dates.Count > 0) {
                                    return _commandResult.BadRequest();
                                } else {
                                    _prospectRepository.Delete(prospect);

                                        await _unityOfWork.Commit();

                                            return _commandResult.NoContent();
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