using Dapper;

using Infrastructure.Sessions;
using Domain.Requested.ViewModels;
using Domain.Requested.QueryRepositories;

    namespace Infrastructure.QueryRepositories.Requested {
        public class ProspectQueryRepository : IProspectQueryRepository {
            private Session _session;
            public ProspectQueryRepository(Session session) {
                _session = session;
            }

                public async Task<IEnumerable<ListProspectViewModel>> List(int page, int length) {
                    var sql = @"
                        SELECT
                            ""P"".""Id"",
                            ""P"".""Name"",
                            ""P"".""Goal"",
                            ""P"".""Status_Active"",
                            ""P"".""Contact"",
                            ""P"".""Biography"",
                            ""P"".""Status_Available"",
                            ""P"".""Birth"",
                            ""P"".""Picture"",
                            ""P"".""CreatedAt"",
                            ""P"".""UpdatedAt""
                        FROM
                            ""Prospects"" AS ""P""
                        ORDER BY
                            ""P"".""Name""
                        LIMIT
                            @Length
                        OFFSET
                            @Offset
                    ";
                    var prospects = await _session.Connection.QueryAsync<ListProspectViewModel>(sql, new {
                        Length = length,
                        Offset = (page - 1) * length
                    });

                        return prospects;
                }
                public async Task<int> Count() {
                    var sql = @"
                        SELECT
                            COUNT(*)
                        FROM
                            ""Prospects"" AS ""P""
                    ";
                    var prospects = await _session.Connection.ExecuteScalarAsync<int>(sql);

                        return prospects;
                }
        }
    }