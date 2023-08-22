using Dapper;

using Infrastructure.Sessions;
using Domain.Requester.ViewModels;
using Domain.Requester.QueryRepositories;

    namespace Infrastructure.QueryRepositories.Requester {
        public class DateQueryRepository : IDateQueryRepository {
            private Session _session;
            public DateQueryRepository(Session session) {
                _session = session;
            }

                public async Task<IEnumerable<ListDateViewModel>> List(int page, int length) {
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
                        Offset = (page - 1) * length
                    },
                        splitOn: "Latitude"
                    );

                        return dates;
                }
                public async Task<int> Count() {
                    var sql = @"
                        SELECT
                            COUNT(*)
                        FROM
                            ""Dates"" AS ""D""
                    ";
                    var dates = await _session.Connection.ExecuteScalarAsync<int>(sql);

                        return dates;
                }
        }
    }