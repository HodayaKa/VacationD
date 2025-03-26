using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.Entities;
using VacationD.Core.Repositories;
using VacationD.Core.Services;

namespace VacationD.Service
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetList()
        {
            return _userRepository.GetList();
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        IEnumerable<object> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}