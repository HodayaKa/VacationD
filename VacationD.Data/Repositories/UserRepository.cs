using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<User> GetAll()
        {
            return (List<User>)_context.User;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task <User> AddAsync(User user)
        {
            _context.Users.Add(user);
           await _context .SaveChangesAsync();
            return user;
        }

        public User Update(User user)
        {
            var idUser = (user.id);
            user.name= user.name;
            user.email = user.email;
            return user;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
            }
        }
        public IEnumerable<User> GetList()
        {
            return _context.Users.Include(u => u.Vacations);
        }

        List<User> IUserRepository.GetList()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.GetByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
    
}
