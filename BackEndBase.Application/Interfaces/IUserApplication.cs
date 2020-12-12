using BackEndBase.Application.ViewModel.User;

namespace BackEndBase.Application.Interfaces
{
    public interface IUserApplication : IApplication
    {
        void AddUser(RegisterUserViewModel usuarioViewModel);
    }
}