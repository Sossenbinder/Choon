using Microsoft.EntityFrameworkCore;

namespace Choon.Api.Features.Common.Infrastructure.Persistence.Migrations;

public class DatabaseMigrator(ChoonDbContext choonDbContext) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await choonDbContext.Database.MigrateAsync(cancellationToken: stoppingToken);
    }
}