using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Entities;
using BackEndBase.Domain.Interfaces.Data;
using BackEndBase.Domain.Interfaces.Services;
using BackEndBase.Domain.Services.Abstracts;

namespace BackEndBase.Domain.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IBus bus, ITokenService tokenService) : base(bus)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public string Authenticate(string email, string senha)
        {
            var user = _userRepository.Get(email, senha);
            if (user == null)
            {
                if (_userRepository.GetUserByEmail(email) == null)
                {
                    NotifyValidationError("User not found.");
                }
                NotifyValidationError("Wrong Password.");
                return null;
            }
            return _tokenService.GenerateToken(user);
        }
    }
}