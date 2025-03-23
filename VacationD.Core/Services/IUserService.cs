﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.Entities;

namespace VacationD.Core.Services
{
    public interface IUserService
    {
        List<User> GetList();

        User? GetById(int id);

        User Add(User user);

        User Update(User user);

        void Delete(int id);
    }

}
