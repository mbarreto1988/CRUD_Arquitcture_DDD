using User_1.Aplication.DTOs;
using User_1.Domain.Entities;

namespace User_1.Application.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task PatchUserAsync(int id, UpdateUserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
