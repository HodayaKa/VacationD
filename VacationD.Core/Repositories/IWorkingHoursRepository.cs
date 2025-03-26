using VacationD.Core.Entities;
using System.Threading.Tasks;

namespace VacationD.Core.Repositories
{
    public interface IWorkingHoursRepository
    {
        Task AddAsync(WorkingHours workingHours);
        Task<WorkingHours> GetByUserAndDateAsync(int userId, DateTime date);
    }

    public WorkingHours GetById(int id);
    public void Update(WorkingHours workingHours);
    public void Delete(WorkingHours workingHours);
}
