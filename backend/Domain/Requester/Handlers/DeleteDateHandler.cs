using MediatR;
using System.Net;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Enumerators;
using Domain.Requester.Commands;
using Domain.Requester.Repositories;

    namespace Domain.Requester.Handlers {
        public class DeleteDateHandler : IHandler<DeleteDateCommand> {
            private readonly IDateRepository _dateRepository;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public DeleteDateHandler(IDateRepository dateRepository, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _dateRepository = dateRepository;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(DeleteDateCommand request, CancellationToken cancellationToken) {
                    var date = await _dateRepository.Read(request.Id);

                        if(date != null) {
                            try {
                                if(date.Status != EStatus.Requested) {
                                    return _commandResult.BadRequest();
                                } else {
                                    _dateRepository.Delete(date);

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