using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.DTOs;
using VacationD.Core.Entities;

namespace VacationD.Core
{
    public  class Mapping
    {
        public  UserDto MapToUserDto(User user)
        {
            return new UserDto {id= user.id, name = user.name, email = user.email, password = user.password, role = user.role, VacationId = user.VacationId, };

        }

       
    }
}
