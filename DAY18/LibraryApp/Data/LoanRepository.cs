using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Models;

namespace LibraryApp.Data
{
    public class LoanRepository : IRepository<LoanModel>
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoanModel>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<LoanModel> GetByIdAsync(string id)
        {
            return await _context.Loans.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<LoanModel>> GetActiveLoansByBookIdAsync(string bookId)
        {
            return await _context.Loans
                .Where(l => l.BookId == bookId && l.ReturnDate == null)
                .ToListAsync();
        }

        public async Task AddAsync(LoanModel entity)
        {
            _context.Loans.Add(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(LoanModel entity)
        {
            var existing = await GetByIdAsync(entity.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
            }
        }

        public async Task DeleteAsync(LoanModel entity)
        {
            var existing = await GetByIdAsync(entity.Id);
            if (existing != null)
            {
                _context.Loans.Remove(existing);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsBookAvailableAsync(string bookId)
        {
            return !await _context.Loans.AnyAsync(l => l.BookId == bookId && l.ReturnDate == null);
        }
    }
}