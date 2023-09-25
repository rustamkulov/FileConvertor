using FileConvertor.Dtos.Login;

namespace FileConvertor.Integrated.Interfaces.Login
{
    public interface ILoginService
    {
        Task<bool> Login(LoginDto loginDto);
    }
}
