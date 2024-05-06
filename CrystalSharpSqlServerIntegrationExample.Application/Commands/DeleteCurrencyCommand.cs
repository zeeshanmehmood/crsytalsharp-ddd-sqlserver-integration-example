using System;
using CrystalSharp.Application;
using CrystalSharpSqlServerIntegrationExample.Application.Responses;

namespace CrystalSharpSqlServerIntegrationExample.Application.Commands
{
    public class DeleteCurrencyCommand : ICommand<CommandExecutionResult<DeleteCurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
    }
}
