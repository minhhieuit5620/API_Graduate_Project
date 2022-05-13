using System.Collections.Generic;
using System.Linq;

namespace KSHYDatabase
{
    public partial interface IRepository<T> where T : class
    {
        T GetById(object id);
        bool ExistsById(object id);
        IList<T> Gets();
        int? Insert(T entity);
        int? Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(object id);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        (int Code, string Message) GetError();
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}
