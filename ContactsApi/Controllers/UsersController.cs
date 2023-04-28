using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ServicesAbstractions;
using Utils.Api;
using Utils.Dtos.User;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto newUser)
        {
            try
            {
                await _userService.Create(newUser);

                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.GetAll();

                return Ok(new ApiResponse<List<UserResponseDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updatedUser)
        {
            try
            {
                await _userService.Update(id, updatedUser);

                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [Authorize(Policy = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToAdmin([FromRoute] int id)
        {
            try
            {
                await _userService.UpdateToAdmin(id);

                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [Authorize(Policy = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userService.Delete(id);

                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }
    }
}
