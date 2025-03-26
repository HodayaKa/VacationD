

namespace VacationD.Core.Repositories
{
    internal class DbSet<T> where T : class
    {
        internal void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        internal T? Find(int id)
        {
            throw new NotImplementedException();
        }

        internal void Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<T> ToList()
        {
            throw new NotImplementedException();
        }

        internal void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}