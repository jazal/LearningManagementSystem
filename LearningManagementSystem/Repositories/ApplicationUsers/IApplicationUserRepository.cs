using LearningManagementSystem.Repositories.ApplicationUsers.Dtos;

namespace LearningManagementSystem.Repositories.ApplicationUsers
{
    public interface IApplicationUserRepository
    {
        UserDto GetUserById(string id);
    }
}