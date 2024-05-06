using System;
using CrystalSharp.Application;
using CrystalSharpSqlServerIntegrationExample.Application.Responses;

namespace CrystalSharpSqlServerIntegrationExample.Application.Commands
{
    public class ChangeCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
