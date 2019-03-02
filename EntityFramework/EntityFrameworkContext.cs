using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Examples
{
	public abstract class EntityFrameworkContext : DbContext
	{
		protected EntityFrameworkContext()
		{
			Configure();
		}

		protected EntityFrameworkContext(string connectionString) : base(connectionString)
		{
			Configure();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
			modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
			OnModelCreatingCustom(modelBuilder);
		}

		protected abstract void OnModelCreatingCustom(DbModelBuilder modelBuilder);

		private void Configure()
		{
			Configuration.AutoDetectChangesEnabled = false;
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}
	}
}
