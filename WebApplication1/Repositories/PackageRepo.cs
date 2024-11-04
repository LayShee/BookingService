using BookingService.Data;
using BookingService.Dto;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Repositories
{
    public class PackageRepo
    {
        private readonly BookingDBContext _context;
        public PackageRepo(BookingDBContext context)
        {
            _context = context;
        }

        public async Task<List<Packages>> GetAll()
        {
            return await _context.Packages.ToListAsync();
        }
        public async Task<Packages> GetById(int packageId)
        {
            return await _context.Packages.FindAsync(packageId);
        }


        public async Task<bool> PurchasePackage(UserPackages userPackages)
        {
            await _context.UserPackages.AddAsync(userPackages);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UserInfoDto> GetAllPackages(int UserID)
        {
            var user = (from u in _context.Users
                                 join up in _context.UserPackages on u.Id equals up.UserId
                                 join p in _context.Packages on up.PackageId equals p.PackageId
                                 group new { p, up } by new { u.Id, u.Username, u.Email} into userGroup
                                 select new UserInfoDto
                                 {
                                     Id = userGroup.Key.Id,
                                     Username = userGroup.Key.Username,
                                     Email = userGroup.Key.Email, 
                                     Packages = userGroup.Select(p => new PackageInfoDto
                                     {
                                         PackageId = p.p.PackageId,
                                         PackageName = p.p.PackageName,
                                         Country = p.p.Country,
                                         ExpirationDate = p.p.ExpirationDate,
                                         RemainingCredits = p.up.CreditsRemaining,
                                         ExpiredStatus = p.p.ExpirationDate < DateTime.Now.Date ? 0 : 1
                                     }).ToList()
                                 }).FirstOrDefault();

            return user;
        }
    }
}
