using BackEndBase.Domain.Bus;
using BackEndBase.Domain.CommandHandlers.Base;
using BackEndBase.Domain.Commands;
using BackEndBase.Domain.Entities;
using BackEndBase.Domain.Events;
using BackEndBase.Domain.Interfaces.Data;
using Mapster;

namespace BackEndBase.Domain.CommandHandlers;

public class UserCommandHandler : CommandHandler, IHandler<AddUserCommand>
{
    private readonly IUserRepository _userRepository;

    public UserCommandHandler(IBus bus, IUserRepository userRepository) : base(bus)
    {
        _userRepository = userRepository;
    }

    public void Handle(AddUserCommand message)
    {
        var user = message.Adapt<User>();

        var existingUser = _userRepository.GetUserByEmail(message.Email);

        if (existingUser != null)
        {
            NotifyValidationError("Existing User");
            return;
        }

        _userRepository.AddUser(user);

        if (message.ShouldCommit)
        {
            _userRepository.Save();
        }
    }
}