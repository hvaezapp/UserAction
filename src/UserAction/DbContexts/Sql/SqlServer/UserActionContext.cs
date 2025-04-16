using Microsoft.EntityFrameworkCore;

namespace UserAction.DbContexts.Sql.SqlServer
{
    public class UserActionContext : DbContext
    {
        public UserActionContext(DbContextOptions<UserActionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(Program).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
