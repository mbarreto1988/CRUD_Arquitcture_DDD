using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_1.Aplication.DTOs;
using User_1.Application.Services;
using User_1.Domain.Entities;


namespace User_1.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await _userService.AddUserAsync(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest("User ID mismatch");
            }
            try
            {
                await _userService.UpdateUserAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Pacht(int id, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                await _userService.PatchUserAsync(id, userDto);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
