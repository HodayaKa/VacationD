using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationD.Core.Entities
{
    public class WorkingHours
    {
      
        public int id { get; set; }
        public DateTime date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<User> Users { get; set; }
        public int UserId { get; set; }


    }
}
