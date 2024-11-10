using Movie_App.Models.DTO;

namespace Movie_App.Repositories.Abstract;

public interface IUserAuthenticationService
{
    Task<Status> LoginAsync(LoginModel model);
    Task LogoutAsync();
    Task<Status> RegisterAsync(RegistrationModel model);
    //Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
}