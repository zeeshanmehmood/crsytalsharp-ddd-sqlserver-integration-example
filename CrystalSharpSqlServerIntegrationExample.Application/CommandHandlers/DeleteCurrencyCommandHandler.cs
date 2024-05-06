using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Domain;
using CrystalSharpSqlServerIntegrationExample.Application.Commands;
using CrystalSharpSqlServerIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpSqlServerIntegrationExample.Application.Infrastructure;
using CrystalSharpSqlServerIntegrationExample.Application.Responses;

namespace CrystalSharpSqlServerIntegrationExample.Application.CommandHandlers
{
    public class DeleteCurrencyCommandHandler : CommandHandler<DeleteCurrencyCommand, DeleteCurrencyResponse>
    {
        private readonly AppDbContext _dbContext;

        public DeleteCurrencyCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<DeleteCurrencyResponse>> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Currency existingCurrency = await _dbContext.Currency.SingleOrDefaultAsync(x =>
                x.GlobalUId == request.GlobalUId
                && x.EntityStatus == EntityStatus.Active,
                cancellationToken)
                .ConfigureAwait(false);

            if (existingCurrency == null)
            {
                return await Fail("Currency not found.");
            }

            existingCurrency.Delete();

            // Uncomment the following line for permanent deletion from the database.
            //_dbContext.Remove(existingCurrency);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            DeleteCurrencyResponse response = new() { GlobalUId = existingCurrency.GlobalUId };

            return await Ok(response);
        }
    }
}
