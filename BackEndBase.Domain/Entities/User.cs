using BackEndBase.Domain.Entities.Abstracts;
using System;

namespace BackEndBase.Domain.Entities
{
    public class User : Entity<User>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}