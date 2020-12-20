using BackEndBase.Domain.Entities;

namespace BackEndBase.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public User GetUserByEmail(string email);

        public string Authenticate(string email, string senha);
    }
}