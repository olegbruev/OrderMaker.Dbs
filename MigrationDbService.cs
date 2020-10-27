using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mtd.OrderMaker.Dbs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mtd.OrderMaker.Dbs
{
    public class MigrationDbService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger logger;

        public MigrationDbService(IServiceProvider serviceProvider, ILogger<MigrationDbService> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<OrderMakerContext>();
            bool dbMigration = false;
            try
            {
                IEnumerable<string> pm = await dbContext.Database.GetPendingMigrationsAsync();
                dbMigration = pm.Any();
            }
            catch (SqlException ex)
            {
                logger.LogError(ex.Message);
            }


            if (dbMigration)
            {
                await dbContext.Database.MigrateAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
