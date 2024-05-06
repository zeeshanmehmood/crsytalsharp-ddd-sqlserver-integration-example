using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrystalSharp.Application;
using CrystalSharp.Application.Execution;
using CrystalSharpSqlServerIntegrationExample.Api.Dto;
using CrystalSharpSqlServerIntegrationExample.Application.Commands;
using CrystalSharpSqlServerIntegrationExample.Application.Queries;
using CrystalSharpSqlServerIntegrationExample.Application.ReadModels;
using CrystalSharpSqlServerIntegrationExample.Application.Responses;

namespace CrystalSharpSqlServerIntegrationExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public CurrencyController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult<CurrencyResponse>>> Post([FromBody] CreateCurrencyRequest request)
        {
            CreateCurrencyCommand command = new() { Name = request.Name };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult<CurrencyResponse>>> Put([FromBody] ChangeCurrencyRequest request)
        {
            ChangeCurrencyCommand command = new() { GlobalUId = request.GlobalUId, Name = request.Name };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{globalUId}")]
        public async Task<ActionResult<CommandExecutionResult<DeleteCurrencyResponse>>> Delete(Guid globalUId)
        {
            DeleteCurrencyCommand command = new() { GlobalUId = globalUId };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CurrencyReadModelList>>> Get()
        {
            CurrencyListQuery query = new();

            return await _queryExecutor.Execute(query, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{globalUId}")]
        public async Task<ActionResult<QueryExecutionResult<CurrencyReadModel>>> GetDetail(Guid globalUId)
        {
            CurrencyDetailQuery query = new() { GlobalUId = globalUId };

            return await _queryExecutor.Execute(query, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
