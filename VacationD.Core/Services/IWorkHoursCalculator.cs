using System;
using System.Threading.Tasks;
using VacationD.Core.Entities;

namespace VacationD.Core.Services
{
    public interface IWorkHoursCalculator
    {
        Task<double> CalculateHoursWorkedAsync(User user, DateTime start, DateTime end);
    }
}
