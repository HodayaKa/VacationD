using System;
using VacationD.Core.Entities;


namespace VacationD.Core.Services
{
    public class WorkHoursCalculator : IWorkHoursCalculator
    {
        public Task<double> CalculateHoursWorkedAsync(User user, DateTime startTime, DateTime endTime)
        {
            if (endTime <= startTime)
            {
                throw new ArgumentException("EndTime must be greater than StartTime");
            }
               double totalHours = (endTime - startTime).TotalHours;


            return Task.FromResult(totalHours);
        }
    }
}
