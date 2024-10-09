using HARMONIA.Domain.DTOs.Auth;

namespace H_API.Services.Interfaces
{
    public interface IAuthService
    {
        public LogInOutput LogIn(LogInInput dto);
        public LogInOutput RefreshToken(string refreshToken);
    }
}
