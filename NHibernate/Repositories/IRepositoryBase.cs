using System.Collections.Generic;

namespace Examples
{
    public interface IRepositoryBase<T>
    {
        IList<T> List();
        T Select(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}