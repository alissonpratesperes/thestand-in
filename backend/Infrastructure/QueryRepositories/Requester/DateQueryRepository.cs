using Dapper;

using Infrastructure.Sessions;
using Domain.Requested.ViewModels;
using Domain.Requester.ViewModels;
using Domain.Requester.QueryRepositories;

    namespace Infrastructure.QueryRepositories.Requester {
        public class DateQueryRepository : IDateQueryRepository {
            private Session _session;
            public DateQueryRepository(Session session) {
                _session = session;
            }

                public async Task<IEnumerable<ListDateViewModel>> List(int page, int length, int? status) {
                    var sql = @"
                        SELECT
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
                            ""Dates"" AS ""D""
                        WHERE
                            ""D"".""Status"" = @Status
                        ORDER BY
                            ""D"".""Name""
                        LIMIT
                            @Length
                        OFFSET
                            @Offset
                    ";
                    var dates = await _session.Connection.QueryAsync<ListDateViewModel, CoordinateViewModel, ListDateViewModel>(sql, (date, coordinate) => {
                        date.Location = coordinate;

                            return date;
                    }, new {
                        Length = length,
                        Offset = (page - 1) * length,
                        Status = status
                    },
                        splitOn: "Latitude"
                    );

                        return dates;
                }
                public async Task<int> Count(int? status) {
                    var sql = @"
                        SELECT
                            COUNT(*)
                        FROM
                            ""Dates"" AS ""D""
                        WHERE
                            ""D"".""Status"" = @Status
                    ";
                    var dates = await _session.Connection.ExecuteScalarAsync<int>(sql, new {
                        Status = status
                    });

                        return dates;
                }
                public async Task<GetDateViewModel> Get(Guid id) {
                    var sql = @"
                        SELECT
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
                            ""D"".""Location_Longitude"" AS ""Longitude"",

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
                            ""Dates"" AS ""D""
                        LEFT JOIN
                            ""Prospects"" AS ""P""
                        ON
                            ""P"".""Id"" = ""D"".""ProspectId""
                        WHERE
                            ""D"".""Id"" = @Id
                    ";
                    var date = await _session.Connection.QueryAsync<GetDateViewModel, CoordinateViewModel, ListProspectViewModel, StatusViewModel, GetDateViewModel>(sql, (date, coordinate, prospect, status) => {
                        if(coordinate != null)
                            date.Location = coordinate;
                        if(prospect != null)
                            date.Prospect = prospect;
                        if(status != null)
                            prospect.Status = status;

                            return date;
                    }, new {
                        Id = id
                    },
                        splitOn: "Latitude, Id, Active"
                    );

                        return date.FirstOrDefault();
                }
        }
    }