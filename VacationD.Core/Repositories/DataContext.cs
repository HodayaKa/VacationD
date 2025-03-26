using Microsoft.EntityFrameworkCore;
using VacationD.Core.Entities;



namespace VacationD.Core.Repositories
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public object WorkingHours { get; internal set; }
    }



public DataContext(IConfiguration configuration)
{
        _configuration = configuration;
}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
}
}
