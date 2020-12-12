using AutoMapper;
using BackEndBase.Application.Base;
using BackEndBase.Application.Interfaces;
using BackEndBase.Application.ViewModel.User;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Commands;

namespace BackEndBase.Application.Concretes
{
    public class UserApplication : ApplicationBase, IUserApplication
    {
        public UserApplication(IMapper mapper, IBus bus) : base(mapper, bus)
        {
        }

        public void AddUser(RegisterUserViewModel registerUserViewModel)
        {
            var command = Mapper.Map<AddUserCommand>(registerUserViewModel);
            SendCommand(command);
        }
    }
}