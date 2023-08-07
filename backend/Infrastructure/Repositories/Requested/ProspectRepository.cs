using Microsoft.EntityFrameworkCore;

using Domain.Shared.Entities;
using Infrastructure.Contexts;
using Domain.Requested.Models;
using Domain.Requested.Repositories;

    namespace Infrastructure.Repositories.Requested {
        public class ProspectRepository : IProspectRepository {
            private readonly Context _context;
            public ProspectRepository(Context context) {
                _context = context;
            }

                public async Task Create(Prospect prospect)
                    =>  await _context.Prospects.AddAsync(prospect);

                public async Task<Prospect?> Read(Guid id)
                    =>  await _context.Prospects.Where(prospect => prospect.Id == id).Include(prospect => prospect.Dates).FirstOrDefaultAsync();

                public void Update(Prospect prospect)
                    =>  _context.Entry(prospect).State = EntityState.Modified;

                public void Delete(Prospect prospect)
                    =>  _context.Prospects.Remove(prospect);
        }
    }