using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ServicesAbstractions;
using Utils.Api;
using Utils.Dtos.Auth;

namespace ContactsApi.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestDto loginRequestDto) 
        {
            try
            {
                var token = _authService.Login(loginRequestDto);

                if (token == string.Empty) 
                {
                    return BadRequest(new ApiResponse("Dados de login inválidos! Verifique e tente novamente."));
                }

                return Ok(new ApiResponse<string>(token));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }
    }
}