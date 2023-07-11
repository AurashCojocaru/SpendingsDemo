//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Spendings.Api.Models;
//using Spendings.DataAccess;
//using Spendings.Logic;

//namespace Spendings.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TransactionsController : ControllerBase
//    {
//        private readonly ITransactionsRepo _transactionsRepo;

//        public TransactionsController(ITransactionsRepo transactionsRepo)
//        {
//            _transactionsRepo = transactionsRepo;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Transaction>>> All(CancellationToken ct)
//        {
//            var fromDb = await _transactionsRepo.GetAll(ct);
//            return Ok(fromDb);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Transaction>> Create(TransactionCreateModel model, CancellationToken ct)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            Transaction toAdd = new Transaction()
//            {
//                Date = model.Date,
//                Description = model.Description,
//                Name = model.Name,
//                Value = model.Value
//            };
//            await _transactionsRepo.Add(toAdd, ct);
//            return Ok(toAdd);
//        }
//    }
//}
