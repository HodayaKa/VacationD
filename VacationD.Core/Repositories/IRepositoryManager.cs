using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationD.Core.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }

        void Save();
    }
}
