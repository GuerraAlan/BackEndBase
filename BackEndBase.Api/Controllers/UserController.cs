using BackEndBase.Api.Controllers.Abstracts;
using BackEndBase.Application.Interfaces;
using BackEndBase.Application.ViewModel.User;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Interfaces.Notifications;
using BackEndBase.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBase.Api.Controllers
{
    [Route("api/v1/User")]
    public class UserController : BaseController
    {
        private readonly IUserApplication _userApplcation;

        public UserController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IUserApplication userApplcation) : base(bus, notifications)
        {
            _userApplcation = userApplcation;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] RegisterUserViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                InvalidViewModelNotify();
                return Response();
            }

            _userApplcation.AddUser(usuarioViewModel);

            return Response(true);
        }
    }
}