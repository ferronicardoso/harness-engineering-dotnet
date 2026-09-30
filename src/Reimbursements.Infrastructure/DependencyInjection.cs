using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Reimbursements.Infrastructure.Persistence;

namespace Reimbursements.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ReimbursementsDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}
