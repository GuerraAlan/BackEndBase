using BackEndBase.Api.Base;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Interfaces.Notifications;
using BackEndBase.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BackEndBase.Api.Controllers.Abstracts
{
    public class BaseController : Controller
    {
        protected readonly IDomainNotificationHandler<DomainNotification> Notifications;
        protected readonly IBus Bus;

        public BaseController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            Bus = bus;
            Notifications = notifications;
        }

        protected void InvalidViewModelNotify()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string codigo, string mensagem)
        {
            Bus.RaiseEvent(new DomainNotification(codigo, mensagem));
        }

        protected IActionResult Response(object result = null)
        {
            return Response<object>(result);
        }

        protected IActionResult Response<T>(T result)
        {
            if (ValidOperation())
            {
                return Ok(new ReturnContentJson<T>(true, result));
            }
            return BadRequest(new ReturnContentJson<T>(false, result, Notifications.GetNotifications().Select(n => n.Value)));
        }

        protected bool ValidOperation()
        {
            return (!Notifications.HasNotifications());
        }
    }
}