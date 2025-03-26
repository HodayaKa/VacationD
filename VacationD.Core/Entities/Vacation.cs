using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationD.Core.Entities
{
    public enum request
    {
        Vacation,
        Sickness
    }

    public class Vacation
    {
        public request type { get; set;}
        public int id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<User> Users { get; set; }

    }
}
