using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MultiTenancyTrials.EntityFrameworkCore
{
    public static class MultiTenancyTrialsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MultiTenancyTrialsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MultiTenancyTrialsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
