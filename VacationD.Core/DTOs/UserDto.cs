using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.Entities;

namespace VacationD.Core.DTOs
{
    public class UserDto
    {
        public string name { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public ICollection<Vacation> Vacations { get; set; }
        public int VacationId { get; set; }
        private WorkingHours workingHours { get; set; }

    }
}
