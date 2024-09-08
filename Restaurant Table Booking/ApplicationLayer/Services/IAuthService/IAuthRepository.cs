using ApplicationLayer.DTOs.AuthDto.ResponseDtos;
using DomainLayer.Entities.IdentityDbUser;
using Shared.Response;

namespace ApplicationLayer.Services.IAuthService
{
    public interface IAuthRepository
    {
        string CreateJWTToken(ApplicationUser user, List<string> roles);
        string GenerateRefreshToken();
        Task<LoginResponseDto> LoginAsync(string username, string password);
        Task<ResponseModel> LogoutAsync(string accessToken);
        Task<LoginResponseDto> RefreshTokenResponse(string accessToken, string refreshToken);
        Task<ResponseModel> ChangePasswordAsync(string userName, string password, string newPassword);
        Task<ResponseModel> CreateAsync(ApplicationUser identityUser, string password, string[] role);
    }
}
