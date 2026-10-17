using ComfySelf.Identity.Entities;
using ComfySelf.Identity.Models;

namespace ComfySelf.Identity.Services.Abstractions
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<TokenResponseDTO?> LoginAsync(UserDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO request);
    }
}
