using BackEndBase.Application.ViewModel.Request.User;

namespace BackEndBase.Application.Interfaces;

public interface IUserApplication : IApplication
{
    void AddUser(RegisterUserViewModel usuarioViewModel);

    string Authenticate(LoginViewModel loginViewModel);
}