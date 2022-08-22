using BackEndBase.Domain.Entities;

namespace BackEndBase.Domain.Interfaces.Data;

public interface IUserRepository : IRepositoryBase<User>
{
    User GetUserByEmail(string email);

    void AddUser(User user);

    public User Get(string email, string password);
}