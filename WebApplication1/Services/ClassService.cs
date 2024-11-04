using AutoMapper;
using BookingService.Models;
using BookingService.Repositories;

namespace BookingService.Services
{
    public class ClassService
    {
        private readonly ClassRepo _classRepo;
        private readonly IMapper _mapper;

        public ClassService(ClassRepo classRepo, IMapper mapper)
        {
            _classRepo = classRepo;
            _mapper = mapper;
        }
        public async Task<List<Classes>> GetAll()
        {
            return await _classRepo.GetAll();
        }
    }
}
