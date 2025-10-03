using User_1.Aplication.DTOs;
using User_1.Domain.Entities;

namespace User_1.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task PatchUserAsync(int id, UpdateUserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
