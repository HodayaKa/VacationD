using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.Entities;
using VacationD.Core.Repositories;

namespace VacationD.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return (List<User>)_context.User;
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.id == id);
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Update(User user)
        {
            var existingUser = GetById(user.id);
            if (existingUser is null)
            {
                throw new Exception("User not found");
            }
            existingUser.name = user.name;
            existingUser.email = user.email;
            return existingUser;
        }

        public void Delete(int id)
        {
            var existingUser = GetById(id);
            if (existingUser is not null)
            {
                _context.Users.Remove(existingUser);
            }
        }
    }

}
