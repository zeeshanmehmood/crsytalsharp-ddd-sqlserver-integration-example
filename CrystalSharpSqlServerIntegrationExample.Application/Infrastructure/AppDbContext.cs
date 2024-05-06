using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrystalSharp.MsSql.Database;
using CrystalSharpSqlServerIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;

namespace CrystalSharpSqlServerIntegrationExample.Application.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly IMsSqlEntityFrameworkCoreContext _msSqlEfContext;
        public DbSet<Currency> Currency { get; set; }

        public AppDbContext()
        {
            //
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IMsSqlEntityFrameworkCoreContext msSqlEfContext)
            : base(options)
        {
            _msSqlEfContext = msSqlEfContext;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _msSqlEfContext.SaveChanges(this, cancellationToken).ConfigureAwait(false);
        }
    }
}
