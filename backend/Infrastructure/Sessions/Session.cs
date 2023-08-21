using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

    namespace Infrastructure.Sessions {
        public class Session : IDisposable {
            private Guid _id;
            public IDbConnection Connection { get; }
            public Session(IConfiguration configuration) {
                _id = Guid.NewGuid();
                Connection = new SqliteConnection(configuration["Database:Connection"]);
                Connection.Open();
            }

                public void Dispose()
                    =>  Connection?.Dispose();
        }
    }