using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Notifications;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace BackEndBase.Domain.Services.Abstracts;

public abstract class ServiceBase
{
    private readonly IBus _bus;

    protected ServiceBase(IBus bus)
    {
        _bus = bus;
    }

    protected void NotifyValidationError(ValidationResult validationResult)
    {
        foreach (var erro in validationResult.Errors)
        {
            Console.WriteLine(erro.ErrorMessage);
            _bus.RaiseEvent(new DomainNotification(erro.PropertyName, erro.ErrorMessage));
        }
    }

    protected void NotifyValidationError(string errorMessage)
    {
        var errors = new List<ValidationFailure> { new(null, errorMessage) };

        var validationResult = new ValidationResult(errors);

        NotifyValidationError(validationResult);
    }
}