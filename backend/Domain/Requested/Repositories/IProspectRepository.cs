using Domain.Requested.Models;

    namespace Domain.Requested.Repositories {
        public interface IProspectRepository {
            Task Create(Prospect prospect);
            Task<Prospect?> Read(Guid id);
            void Update(Prospect prospect);
            void Delete(Prospect prospect);
        }
    }