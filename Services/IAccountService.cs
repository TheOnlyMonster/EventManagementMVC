using EventManagementWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EventManagementWebApp.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
        Task<SignInResult> LoginUserAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}
