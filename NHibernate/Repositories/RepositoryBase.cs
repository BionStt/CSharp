using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        private IUoW _uow;

        public RepositoryBase(IUoW uow)
        {
            _uow = uow;
        }

        protected ISession Session { get { return _uow.Session; } }

        public IList<T> List()
        {
            return Session.Query<T>().ToList();
        }

        public T Select(int id)
        {
            return Session.Get<T>(id);
        }

        public void Insert(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }
    }
}