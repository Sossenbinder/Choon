using Choon.Api.Features.Common.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Choon.Api.Migrations;

public class DatabaseMigrator(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();

        var choonDbContext = scope.ServiceProvider.GetRequiredService<ChoonDbContext>();
        
        await choonDbContext.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}