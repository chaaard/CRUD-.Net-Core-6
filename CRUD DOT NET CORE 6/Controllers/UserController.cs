using CRUD.Application.DTOs;
using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DOT_NET_CORE_6.Controllers
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

        [HttpGet("GetUserById{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userDto = await _userService.GetUserById(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userDto = await _userService.GetAllUsers();
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var createdUser = await _userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            var result = await _userService.UpdateUser(userDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
