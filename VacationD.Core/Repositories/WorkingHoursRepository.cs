using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VacationD.Core.Entities;
using VacationD.Core.Repositories;

namespace VacationD.Data.Repositories
{
    public class WorkingHoursRepository : IWorkingHoursRepository
    {
        private readonly DataContext _context;

        public WorkingHoursRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(WorkingHours workingHours)
        {
            await _context.Set<WorkingHours>().AddAsync(workingHours);
            await _context.SaveChangesAsync();
        }

        public async Task<WorkingHours> GetByUserAndDateAsync(int userId, DateTime date)
        {
            return await _context.Set<WorkingHours>()
                .Include(wh => wh.Users)
                .FirstOrDefaultAsync(wh => wh.UserId == userId && wh.date.Date == date.Date);
        }
        public WorkingHours GetById(int id)
        {
            return _context.WorkingHours.Find(id);
        }

        public void Update(WorkingHours workingHours)
        {
            object value = _context.WorkingHours.Update(workingHours);
            _context.SaveChanges();
        }

        public void Delete(WorkingHours workingHours)
        {
            bool v = _context.WorkingHours.Remove(workingHours);
            _context.SaveChanges();
        }
    }
}
