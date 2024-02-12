using CamelFlow_Backend.ModelDto;
using Microsoft.AspNetCore.Mvc;

namespace CamelFlow_Backend.Auth
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterModel model);
        public Task<string> Login(LoginModel model);
    }
}
