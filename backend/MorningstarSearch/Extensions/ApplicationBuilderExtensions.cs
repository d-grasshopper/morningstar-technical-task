using Microsoft.EntityFrameworkCore;

namespace MorningstarSearch.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder MigrateDatabaseChanges<T>(this IApplicationBuilder app) where T : DbContext
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        serviceScope.ServiceProvider.GetService<T>()?.Database.Migrate();

        return app;
    }
}