using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spendings.Api.Handlers;
using Spendings.Api.Models;
using Spendings.DataAccess;
using Spendings.Logic;

namespace Spendings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> All(CancellationToken ct)
        {
            var fromDb = await _mediator.Send(new GetTransactionsQuery(null, null), ct);
            return Ok(fromDb);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> Create([FromBody] TransactionCreateModel model, CancellationToken ct)
        {
            //_mediator.Send()
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //Transaction toAdd = new Transaction()
            //{
            //    Date = model.Date,
            //    Description = model.Description,
            //    Name = model.Name,
            //    Value = model.Value
            //};
            //await _transactionsRepo.Add(toAdd, ct);
            return Ok();
        }
    }
}
