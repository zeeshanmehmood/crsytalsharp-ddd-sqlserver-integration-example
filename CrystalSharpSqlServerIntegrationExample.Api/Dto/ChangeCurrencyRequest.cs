using System;

namespace CrystalSharpSqlServerIntegrationExample.Api.Dto
{
    public class ChangeCurrencyRequest
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
