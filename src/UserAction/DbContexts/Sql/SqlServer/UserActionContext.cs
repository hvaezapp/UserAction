using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserAction.Domain.Entity;
namespace UserAction.DbContexts.Sql.SqlServer;

public class UserActionContext(DbContextOptions<UserActionContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<UserActionHistory> UserActionHistory => Set<UserActionHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
