using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAction.Domain.Entity;

namespace UserAction.Domain.EntityConfiguration;

public class UserActionHistoryConfiguration : IEntityTypeConfiguration<UserActionHistory>
{
    public void Configure(EntityTypeBuilder<UserActionHistory> builder)
    {
        // entity configuration
    }
}
