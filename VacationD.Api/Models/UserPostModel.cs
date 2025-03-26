using VacationD.Core.Entities;

namespace VacationD.Api.Models
{
    public class UserPostModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public int VacationId { get; set; }


    }
}
