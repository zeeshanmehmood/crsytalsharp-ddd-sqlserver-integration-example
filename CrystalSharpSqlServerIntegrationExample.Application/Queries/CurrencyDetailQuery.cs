using System;
using CrystalSharp.Application;
using CrystalSharpSqlServerIntegrationExample.Application.ReadModels;

namespace CrystalSharpSqlServerIntegrationExample.Application.Queries
{
    public class CurrencyDetailQuery : IQuery<QueryExecutionResult<CurrencyReadModel>>
    {
        public Guid GlobalUId { get; set; }
    }
}
