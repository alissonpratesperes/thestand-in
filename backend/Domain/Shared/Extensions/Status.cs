using Domain.Shared.Enumerators;

    namespace Domain.Shared.Extensions {
        public static class Status {
            public static EStatus Select(EStatus requestedStatus) {
                return requestedStatus switch {
                    EStatus.Requested  =>  EStatus.Requested,
                    EStatus.Happening  =>  EStatus.Happening,
                    EStatus.Completed  =>  EStatus.Completed,
                    EStatus.Declined  =>  EStatus.Declined,

                        _ =>  requestedStatus
                };
            }
        }
    }