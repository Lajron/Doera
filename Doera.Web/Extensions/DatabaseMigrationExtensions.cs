using System;
using System.Linq;
using System.Threading.Tasks;
using Doera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Doera.Web.Extensions
{
    public static class DatabaseMigrationExtensions
    {
        public static async Task ApplyMigrationsAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>()
                                             .CreateLogger("DatabaseMigration");
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var pending = await context.Database.GetPendingMigrationsAsync();
                if (pending.Any())
                {
                    logger.LogInformation("Applying {Count} pending migration(s): {Migrations}",
                        pending.Count(), string.Join(", ", pending));
                    await context.Database.MigrateAsync();
                    logger.LogInformation("Database migrations applied successfully.");
                }
                else
                {
                    logger.LogInformation("No pending migrations. Database is up to date.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while applying database migrations.");
                throw; // Re-throw so startup fails visibly if migrations are critical.
            }
        }
    }
}