using AutoMapper;
using BackEndBase.Application.Base;
using BackEndBase.Application.Interfaces;
using BackEndBase.Application.ViewModel.Request.User;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Commands;
using BackEndBase.Domain.Interfaces.Services;

namespace BackEndBase.Application.Concretes
{
    public class UserApplication : ApplicationBase, IUserApplication
    {
        private readonly IUserService _userService;

        public UserApplication(IMapper mapper, IBus bus, IUserService userService) : base(mapper, bus)
        {
            _userService = userService;
        }

        public void AddUser(RegisterUserViewModel registerUserViewModel)
        {
            var command = Mapper.Map<AddUserCommand>(registerUserViewModel);
            SendCommand(command);
        }

        public string Authenticate(LoginViewModel loginViewModel)
        {
            return _userService.Authenticate(loginViewModel.Email, loginViewModel.PasswordHash);
        }
    }
}