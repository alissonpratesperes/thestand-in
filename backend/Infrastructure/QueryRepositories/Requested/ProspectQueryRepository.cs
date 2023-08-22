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
                            ""P"".""Contact"",
                            ""P"".""Biography"",
                            ""P"".""Birth"",
                            ""P"".""Picture"",
                            ""P"".""CreatedAt"",
                            ""P"".""UpdatedAt"",

                            ""P"".""Status_Active"" AS ""Active"",
                            ""P"".""Status_Available"" AS ""Available""
                        FROM
                            ""Prospects"" AS ""P""
                        ORDER BY
                            ""P"".""Name""
                        LIMIT
                            @Length
                        OFFSET
                            @Offset
                    ";
                    var prospects = await _session.Connection.QueryAsync<ListProspectViewModel, StatusViewModel, ListProspectViewModel>(sql, (prospect, status) => {
                        prospect.Status = status;

                            return prospect;
                    }, new {
                        Length = length,
                        Offset = (page - 1) * length
                    },
                        splitOn: "Active"
                    );

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