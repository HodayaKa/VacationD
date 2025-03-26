using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.Entities;

namespace VacationD.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User? GetById(int id);

        Task<User> AddAsync(User user);

        User Update(User user);

        void Delete(int id);
        List<User> GetList();
        Task<User> GetUserByIdAsync(int userId);
        Task GetByIdAsync(int userId);
    }
}
