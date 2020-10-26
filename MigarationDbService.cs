using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mtd.OrderMaker.Dbs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mtd.OrderMaker.Dbs
{
    public class MigarationDbService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        public MigarationDbService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<OrderMakerContext>();
            IEnumerable<string> pm = await dbContext.Database.GetPendingMigrationsAsync();
            bool dbMigration = pm.Any();

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
