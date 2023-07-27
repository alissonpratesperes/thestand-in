using Domain.Requester.Models;

    namespace Domain.Requester.Repositories {
        public interface IDateRepository {
            Task Create(Date date);
            Task<Date?> Read(Guid id);
            void Update(Date date);
            void Delete(Date date);
        }
    }