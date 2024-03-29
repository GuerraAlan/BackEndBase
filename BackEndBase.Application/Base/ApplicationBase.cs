﻿using BackEndBase.Application.Interfaces;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Commands.Base;

namespace BackEndBase.Application.Base;

public abstract class ApplicationBase : IApplication
{
    private readonly IBus _bus;

    protected ApplicationBase(IBus bus)
    {
        _bus = bus;
    }

    protected void SendCommand<TCommand>(TCommand command) where TCommand : Command
    {
        _bus.SendCommand(command);
    }
}