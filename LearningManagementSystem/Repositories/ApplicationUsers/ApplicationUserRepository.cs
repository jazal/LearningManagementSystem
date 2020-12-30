using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.ApplicationUsers.Dtos;
using System.Linq;

namespace LearningManagementSystem.Repositories.ApplicationUsers
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationUserRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public UserDto GetUserByEmailId(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return _mapper.Map<ApplicationUser, UserDto>(user);
        }

        public UserDto GetUserById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id.Trim());
            return _mapper.Map<ApplicationUser, UserDto>(user);
        }
    }
}