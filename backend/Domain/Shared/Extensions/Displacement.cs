using Domain.Shared.Enumerators;

    namespace Domain.Shared.Extensions {
        public static class Displacement {
            public static EDisplacement Choose(EDisplacement requestedDisplacement) {
                return requestedDisplacement switch {
                    EDisplacement.Need  =>  EDisplacement.Need,
                    EDisplacement.Give  =>  EDisplacement.Give,
                    EDisplacement.Outer  =>  EDisplacement.Outer,

                        _ =>  requestedDisplacement
                };
            }
        }
    }