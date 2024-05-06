using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpSqlServerIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events;

namespace CrystalSharpSqlServerIntegrationExample.Application.EventHandlers
{
    public class CurrencyDeletedDomainEventHandler : ISynchronousDomainEventHandler<CurrencyDeletedDomainEvent>
    {
        public async Task Handle(CurrencyDeletedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
