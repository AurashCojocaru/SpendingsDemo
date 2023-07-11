using Spendings.DataAccess;

namespace Spendings.Logic
{
    public interface ITransactionsRepo
    {
        Task<List<Transaction>> GetAll(CancellationToken ct);
        Task<List<Transaction>> GetByMonth(DateTime date, CancellationToken ct = default);
        Task<List<Transaction>> GetByYear(int year, CancellationToken ct = default);
        Task<Transaction> Add(Transaction transaction, CancellationToken ct = default);
    }
}