using Microsoft.EntityFrameworkCore;

using Infrastructure.Contexts;
using Domain.Requester.Models;
using Domain.Requester.Repositories;

    namespace Infrastructure.Repositories.Requester {
        public class DateRepository : IDateRepository {
            private readonly Context _context;
            public DateRepository(Context context) {
                _context = context;
            }

                public async Task Create(Date date)
                    =>  await _context.Dates.AddAsync(date);

                public async Task<Date?> Read(Guid id)
                    =>  await _context.Dates.Where(x => x.Id == id).FirstOrDefaultAsync();

                public void Update(Date date)
                    =>  _context.Entry(date).State = EntityState.Modified;

                public void Delete(Date date)
                    =>  _context.Dates.Remove(date);
        }
    }