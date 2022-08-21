using BackEndBase.Domain.Entities.Abstracts;
using System;

namespace BackEndBase.Domain.Entities
{
    public class User : Entity<User>
    {
        public string Name { get; init; }

        public DateTime BirthDate { get; init; }

        public string Phone { get; init; }

        public string Email { get; init; }

        public string PasswordHash { get; init; }
    }
}