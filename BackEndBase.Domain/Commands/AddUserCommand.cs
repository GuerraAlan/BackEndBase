using BackEndBase.Domain.Commands.Base;
using System;

namespace BackEndBase.Domain.Commands;

public class AddUserCommand : Command
{
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }
}