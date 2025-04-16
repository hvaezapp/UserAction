using UserAction.DbContexts.Sql.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace UserAction.Registeration
{
    public static class RegisterDependency
    {
        public static void RegisterSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserActionContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));

            }, ServiceLifetime.Scoped);
        }

    }
}
