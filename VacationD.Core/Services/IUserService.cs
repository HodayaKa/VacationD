using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.Entities;

namespace VacationD.Core.Services
{
    public interface IUserService
    {
        List<User> GetList();

        User? GetById(int id);

        Task<User> AddAsync(User user);

        User Update(User user);

        void Delete(int id);
        IEnumerable<object> GetAll();
        Task<User> GetByIdAsync(int id);
        Task<double> GetTotalWorkedHoursAsync(int userId, DateTime dateTime1, DateTime dateTime2);
    }

}
