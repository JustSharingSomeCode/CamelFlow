using CamelFlow_Backend.Dtos.Request.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CamelFlow_Backend.Interfaces.Auth
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterModel model);
        public Task<string> Login(LoginModel model);
    }
}
