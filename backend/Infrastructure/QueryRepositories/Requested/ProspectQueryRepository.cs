using Dapper;

using Infrastructure.Sessions;
using Domain.Requested.ViewModels;
using Domain.Requester.ViewModels;
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
                public async Task<GetProspectViewModel> Get(Guid id) {
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
                            ""P"".""Status_Available"" AS ""Available"",

                            ""D"".""Id"",
                            ""D"".""Name"",
                            ""D"".""Title"",
                            ""D"".""Status"",
                            ""D"".""Contact"",
                            ""D"".""Schedule"",
                            ""D"".""Description"",
                            ""D"".""Displacement"",
                            ""D"".""Contribution"",
                            ""D"".""CreatedAt"",
                            ""D"".""UpdatedAt"",
                            
                            ""D"".""Location_Latitude"" AS ""Latitude"",
                            ""D"".""Location_Longitude"" AS ""Longitude""
                        FROM
                            ""Prospects"" AS ""P""
                        LEFT JOIN
                            ""Dates"" AS ""D""
                        ON
                            ""D"".""ProspectId"" = ""P"".""Id""
                        WHERE
                            ""P"".""Id"" = @Id
                    ";
                    var prospect = await _session.Connection.QueryAsync<GetProspectViewModel, StatusViewModel, ListDateViewModel, CoordinateViewModel, GetProspectViewModel>(sql, (prospect, status, date, coordinate) => {
                        if(status !=  null)
                            prospect.Status = status;
                        if(date != null)
                            prospect.Dates.Add(date);
                        if(coordinate != null)
                            date.Location = coordinate;

                            return prospect;
                    }, new {
                        Id = id
                    },
                        splitOn: "Active, Id, Latitude"
                    );
                    var group = prospect.First();

                        group.Dates = prospect.Select(x => x.Dates.FirstOrDefault()).Where(x => x != null).GroupBy(x => x.Id).Select(x => x.First()).ToList();

                            return group;
                }
        }
    }