using BookingService.Data;
using BookingService.Dto;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Repositories
{
    public class UserRepo 
    {
        private readonly BookingDBContext _context;

        public UserRepo(BookingDBContext context)
        {
            _context = context;
        }

        public async Task<Users> GetById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<Users> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> AddUser(Users user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveChanges() 
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
