using BookingService.Data;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Repositories
{
    public class ClassRepo
    {
        private readonly BookingDBContext _context;
        public ClassRepo(BookingDBContext context)
        {
            _context = context;
        }

        public async Task<List<Classes>> GetAll()
        {
            return await _context.Classes.ToListAsync();
        }
    }
}
