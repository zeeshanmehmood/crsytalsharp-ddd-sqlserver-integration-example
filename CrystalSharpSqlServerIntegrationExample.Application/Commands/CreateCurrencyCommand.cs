using CrystalSharp.Application;
using CrystalSharpSqlServerIntegrationExample.Application.Responses;

namespace CrystalSharpSqlServerIntegrationExample.Application.Commands
{
    public class CreateCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public string Name { get; set; }
    }
}
