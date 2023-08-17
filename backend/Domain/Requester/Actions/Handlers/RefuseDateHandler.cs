using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Enumerators;
using Domain.Requester.Repositories;
using Domain.Requester.Actions.Commands;

    namespace Domain.Requester.Actions.Handlers {
        public class RefuseDateHandler : IHandler<RefuseDateCommand> {
            private readonly IDateRepository _dateRepository;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public RefuseDateHandler(IDateRepository dateRepository, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _dateRepository = dateRepository;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(RefuseDateCommand action, CancellationToken cancellationToken) {
                    var date = await _dateRepository.Read(action.Id);

                        if(date != null) {
                            try {
                                if(date.Status == EStatus.Requested && date.ProspectId == action.ProspectId) {
                                    date.Refuse(
                                        status: EStatus.Declined
                                    );

                                        _dateRepository.Update(date);

                                            await _unityOfWork.Commit();

                                                return _commandResult.OK();
                                } else {
                                    return _commandResult.BadRequest();
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