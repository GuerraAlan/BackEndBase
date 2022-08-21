using BackEndBase.Application.Base;
using BackEndBase.Application.Interfaces;
using BackEndBase.Application.ViewModel.Request.User;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Commands;
using BackEndBase.Domain.Interfaces.Services;
using Mapster;

namespace BackEndBase.Application.Concretes
{
    public class UserApplication : ApplicationBase, IUserApplication
    {
        private readonly IUserService _userService;

        public UserApplication(IBus bus, IUserService userService) : base(bus)
        {
            _userService = userService;
        }

        public void AddUser(RegisterUserViewModel registerUserViewModel)
        {
            var command = registerUserViewModel.Adapt<AddUserCommand>();
            SendCommand(command);
        }

        public string Authenticate(LoginViewModel loginViewModel)
        {
            return _userService.Authenticate(loginViewModel.Email, loginViewModel.PasswordHash);
        }
    }
}