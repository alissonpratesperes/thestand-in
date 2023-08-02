using Domain.Shared.Data;
using Infrastructure.Contexts;

    namespace Infrastructure.Shared.Data {
        public class UnityOfWork : IUnityOfWork {
            private readonly Context _context;
            public UnityOfWork(Context context) {
                _context = context;
            }

                public async Task<int> Commit()
                    =>  await _context.SaveChangesAsync();

                public void Rollback()
                    =>  _context.Database.CurrentTransaction?.Rollback();
        }    
    }