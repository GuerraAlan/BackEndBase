using BackEndBase.Domain.Entities;

namespace BackEndBase.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}