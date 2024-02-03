using Choon.Api.Features.Common.Infrastructure.Persistence;
using Choon.Api.Features.Common.Infrastructure.Persistence.Options;
using Choon.Api.Features.Common.Web;
using Choon.Api.Features.Common.Web.Auth;
using Choon.Api.Features.Common.Web.Auth.Middleware;
using Choon.Api.Migrations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Choon.Api.Features.Common;

public static class CommonFeatureModule
{
    public static IServiceCollection RegisterCommonFeatureModule(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<UserDetectionMiddleware>()
            .AddValidatorsFromAssembly(typeof(Program).Assembly)
            .AddHostedService<DatabaseMigrator>()
            .AddDbContext<ChoonDbContext>((sp, options) =>
            {
                var sqlOptions = sp.GetRequiredService<IOptions<SqlOptions>>().Value;
                options.UseNpgsql(sqlOptions.ConnectionString);
            })
            .AddScoped<IUserContext, UserContext>();
    }
}