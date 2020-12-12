using BackEndBase.Domain.Entities;

namespace BackEndBase.Domain.Interfaces.Data
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserByEmail(string messageEmail);

        void AddUser(User user);
    }
}