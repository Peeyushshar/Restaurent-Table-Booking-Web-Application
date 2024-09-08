using ApplicationLayer.DTOs.AuthDto.RequestDtos;
using ApplicationLayer.Services.IAuthService;
using ApplicationLayer.Services.IMailSendService;
using DomainLayer.Entities.IdentityDbUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Table_Booking.Application.DTOs.AuthDto.RequestDtos;
using static Shared.Constants.UserConstants;

namespace Restaurant_Table_Booking_Web_Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMailSender _mailSender;
        public AuthController(IAuthRepository authRepository, IMailSender mailSender)
        {
            _authRepository = authRepository;
            _mailSender = mailSender;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new ApplicationUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
            };
            string[] role = ["Accountant"];
            var identityResult = await _authRepository.CreateAsync(identityUser, registerRequestDto.Password, role);

            if (identityResult != null)
            {
                return Ok(identityResult);
            }
            return BadRequest(identityResult);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            
            var user = await _authRepository.LoginAsync(loginRequest.Username, loginRequest.Password);
            if (user == null)
            {
                return BadRequest(UnauthourizedMessage);
            }
           return Ok(user);
          
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenRequestDto refreshTokenRequest)
        {
          
            var loginResult = await _authRepository.RefreshTokenResponse(refreshTokenRequest.AccessToken, refreshTokenRequest.RefreshToken);

            if (loginResult.IsLoggedIn)
            {
                return Ok(loginResult);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout([FromForm] LogoutRequestDto logoutRequest)
        {
            var logOut = await _authRepository.LogoutAsync(logoutRequest.AccessToken);

            if (logOut.IsSucceeded == false)
            {
                return BadRequest(logOut);
            }

            return Ok(logOut);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordRequestDto changePasswordRequest)
        {

            var result = await _authRepository.ChangePasswordAsync(changePasswordRequest.Username, changePasswordRequest.Password, changePasswordRequest.NewPassword);
           
            if(result.IsSucceeded == false)
            {
                return BadRequest(result);  
            }

            _mailSender.SendMailToUser(changePasswordRequest.Username);
            return Ok(result);  
        }
    }
}
