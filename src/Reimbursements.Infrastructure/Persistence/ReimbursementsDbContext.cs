using Microsoft.EntityFrameworkCore;

namespace Reimbursements.Infrastructure.Persistence;

public sealed class ReimbursementsDbContext(DbContextOptions<ReimbursementsDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReimbursementsDbContext).Assembly);
    }
}
