using AutoMapper;
using BookingService.Dto;
using BookingService.Models;
using BookingService.Repositories;
using System.Security.Claims;

namespace BookingService.Services
{
    public class PackageService
    {
        private readonly PackageRepo _packageRepo;
        private readonly IMapper _mapper;

        public PackageService(PackageRepo packageRepo, IMapper mapper)
        {
            _packageRepo = packageRepo;
            _mapper = mapper;
        }

        public async Task<List<Packages>> GetAll()
        {
            return await _packageRepo.GetAll();
        }

        public async Task<bool> PurchasePackage(PackageIDDto packageIDDto)
        {
            var package = await _packageRepo.GetById(packageIDDto.PackageID);
            var userPackages = new UserPackages
            {
                UserId = packageIDDto.UserID,
                PackageId = packageIDDto.PackageID,
                CreditsRemaining = package.Credits,
                ExpiryStatus = package.ExpirationDate < DateTime.Now.Date ? 1 : 0, //1= expired, 0 = active
            };
            return await _packageRepo.PurchasePackage(userPackages);
        }
    }
}
