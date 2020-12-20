using BackEndBase.Api.Controllers.Abstracts;
using BackEndBase.Application.Interfaces;
using BackEndBase.Application.ViewModel.Request.User;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Interfaces.Notifications;
using BackEndBase.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBase.Api.Controllers
{
    [Route("api/v1/User")]
    public class UserController : BaseController
    {
        private readonly IUserApplication _userApplication;

        public UserController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IUserApplication userApplication) : base(bus, notifications)
        {
            _userApplication = userApplication;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] RegisterUserViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                InvalidViewModelNotify();
                return Response();
            }

            _userApplication.AddUser(usuarioViewModel);

            return Response(true);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InvalidViewModelNotify();
                return Response();
            }

            var userToken = _userApplication.Authenticate(model);

            return Response(userToken);
        }
    }
}