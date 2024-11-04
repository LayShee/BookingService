using AutoMapper;
using BookingService.Dto;
using BookingService.Models;
using BookingService.Repositories;

namespace BookingService.Services
{
    public class UserService
    {
        private readonly UserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly PackageRepo _packageRepo;

        public UserService(UserRepo userRepository, IMapper mapper, PackageRepo packageRepo)
        {
            _userRepo = userRepository;
            _mapper = mapper;
            _packageRepo = packageRepo;
        }

        public async Task<bool> RegisterUserAsync(UserDto userDto)
        {
            // Map the DTO to a User entity
            var user = _mapper.Map<Users>(userDto);
            user.Password = HashPassword(userDto.Password); // Hash password for security

            return await _userRepo.AddUser(user);
        }

        public async Task<Users?> ValidateUser(string email,string password)
        {
            var user = await _userRepo.GetByEmail(email);
            if(user != null) 
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password); ;
                if (isPasswordValid) {
                    return user;
                }
            }
            return null;
        }

        public async Task<Users> GetById(int id)
        {
            var user = await _userRepo.GetById(id);
            return user;
        }

        private string HashPassword(string password)
        {
            // Implement password hashing (e.g., using BCrypt or a similar library)
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<UserInfoDto> GetAllInfoById(int id)
        {
            var user = await _userRepo.GetById(id);
            var userPackage = await _packageRepo.GetAllPackages(id);
            return userPackage;
        }
    }
}
