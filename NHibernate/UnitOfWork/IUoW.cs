using NHibernate;

namespace Examples
{
    public interface IUoW
    {
        ISession Session { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}