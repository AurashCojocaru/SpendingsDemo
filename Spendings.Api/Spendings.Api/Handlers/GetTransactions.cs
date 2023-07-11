using MediatR;
using Spendings.DataAccess;
using Spendings.Logic;

namespace Spendings.Api.Handlers
{
    public record GetTransactionsQuery(DateTime? Month, int? Year) : IRequest<List<Transaction>>;

    public class GetTransactionsHandler : IRequestHandler<GetTransactionsQuery, List<Transaction>>
    {
        private readonly ITransactionsRepo _repo;

        public GetTransactionsHandler(ITransactionsRepo repo)
        {
            _repo = repo;
        }

        public Task<List<Transaction>> Handle(GetTransactionsQuery request, CancellationToken ct)
        {
            if (request.Month.HasValue)
            {
                return _repo.GetByMonth(request.Month.Value, ct);
            }
            if (request.Year.HasValue)
            {
                return _repo.GetByYear(request.Year.Value, ct);
            }
            return _repo.GetAll(ct);
        }
    }
}
