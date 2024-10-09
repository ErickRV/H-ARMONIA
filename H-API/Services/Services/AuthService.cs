using H_API.Services.Interfaces;
using HARMONIA.Domain.DTOs.Auth;

namespace H_API.Services.Services
{
    public class AuthService : IAuthService
    {
        public LogInOutput LogIn(LogInInput dto)
        {
            throw new NotImplementedException();
        }

        public LogInOutput RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
