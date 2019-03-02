using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Examples
{
    public class UoW : IUoW
    {
        private static readonly ISessionFactory _sessionFactory;

        private ITransaction _transaction;

        public ISession Session { get; }

        static UoW()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("Database")))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<IClassMap>())
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .BuildSessionFactory();
        }

        public UoW()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive) { _transaction.Commit(); }
            }
            catch
            {
                RollbackTransaction();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive) { _transaction.Rollback(); }
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}