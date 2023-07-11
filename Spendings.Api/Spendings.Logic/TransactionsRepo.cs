using Microsoft.EntityFrameworkCore;
using Spendings.DataAccess;

namespace Spendings.Logic
{
    public class TransactionsRepo : ITransactionsRepo
    {
        private AppDbContext _context;

        public TransactionsRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction> Add(Transaction transaction, CancellationToken ct)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync(ct);
            return transaction;
        }

        public Task<List<Transaction>> GetAll(CancellationToken ct)
        {
            return _context.Transactions.AsNoTracking().ToListAsync(ct);
        }


        public Task<List<Transaction>> GetByMonth(DateTime date, CancellationToken ct)
        {
            return _context.Transactions
                .Where(d => d.Date.Month == date.Month && d.Date.Year == date.Year)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public Task<List<Transaction>> GetByYear(int year, CancellationToken ct)
        {
            return _context.Transactions
                .Where(d => d.Date.Year == year)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}