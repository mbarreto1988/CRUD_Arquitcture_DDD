using Microsoft.EntityFrameworkCore;
using User_1.Aplication.DTOs;
using User_1.Domain.Entities;
using User_1.Infrastructure.Context;

namespace User_1.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextFile _context;

        public UserRepository(ContextFile context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User1s.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _context.User1s.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.User1s.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task PatchUserAsync(int id, UpdateUserDto userDto)
        {
            var user = await _context.User1s.FindAsync(id);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            if (userDto.FirstName != null) user.FirstName = userDto.FirstName;
            if (userDto.LastName != null) user.LastName = userDto.LastName;
            if (userDto.Address != null) user.Address = userDto.Address;
            if (userDto.Dni != null) user.Dni = userDto.Dni;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.User1s.FindAsync(id);
            if(user == null)
                throw new Exception("Usuario no encontrado");
            _context.User1s.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
