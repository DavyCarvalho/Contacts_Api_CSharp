using Utils.Dtos.Auth;

namespace Services.ServicesAbstractions
{
    public interface IAuthService
    {
        string Login(LoginRequestDto loginRequestDto);
    }
}