using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HRLeaveManagement.Persistence
{
    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<HrLeaveManagementDbContext>
    {
        public HrLeaveManagementDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<HrLeaveManagementDbContext>();
            var connectionString = configuration.GetConnectionString("HRLeaveManagementConnectionString");
            builder.UseSqlServer(connectionString);

            return new HrLeaveManagementDbContext(builder.Options);
        }
    }
}