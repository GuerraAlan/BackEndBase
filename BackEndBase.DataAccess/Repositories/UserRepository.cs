using BackendBase.DataAccess.Context;
using BackendBase.DataAccess.Repositories.Base;
using BackEndBase.Domain.Entities;
using BackEndBase.Domain.Interfaces.Data;

namespace BackendBase.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BaseContext context) : base(context)
        {
        }

        public void AddUser(User user)
        {
            DbSet().Add(user);
        }

        public User GetUserByEmail(string messageEmail)
        {
            return Get(u => u.Email.ToLower().Equals(messageEmail.ToLower()));
        }
    }
}