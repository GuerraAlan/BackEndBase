using BackEndBase.DataAccess.Context;
using BackEndBase.DataAccess.Repositories.Base;
using BackEndBase.Domain.Entities;
using BackEndBase.Domain.Interfaces.Data;

namespace BackEndBase.DataAccess.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(BaseContext context) : base(context)
    {
    }

    public void AddUser(User user)
    {
        DbSet().Add(user);
    }

    public User GetUserByEmail(string email)
    {
        return Get(u => u.Email.ToLower().Equals(email.ToLower()));
    }

    public User Get(string email, string password)
    {
        return Get(u => u.Email.ToLower().Equals(email.ToLower()) && u.PasswordHash == password);
    }
}