using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.Entities;

namespace VacationD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
     : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public List<User> User { get; internal set; }
    }
   


}
