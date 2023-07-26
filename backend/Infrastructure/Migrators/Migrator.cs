using Microsoft.EntityFrameworkCore;

    namespace Infrastructure.Migrators {
        public static class Migrator {
            public static void MigrateDatabase<Context>(this Context context) where Context : DbContext {
                context.Database.Migrate();
            }
        }
    }