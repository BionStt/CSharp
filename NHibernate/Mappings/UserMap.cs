using FluentNHibernate.Mapping;

namespace Examples
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("[User]");
            Table("[Users]");
            LazyLoad();
            Id(x => x.UserId).GeneratedBy.Identity().Column("UserId");
            Map(x => x.Name).Column("Name").Not.Nullable().Length(50);
            Map(x => x.Surname).Column("Surname").Not.Nullable().Length(100);
            Map(x => x.Email).Column("Email").Not.Nullable().Length(250);
            Map(x => x.Login).Column("Login").Not.Nullable().Length(300);
            Map(x => x.Password).Column("Password").Not.Nullable().Length(500);
            Map(x => x.Status).Column("Status").Not.Nullable().Precision(10);
            HasMany(x => x.UsersLogs).KeyColumn("UserId");
            HasMany(x => x.UsersRoles).KeyColumn("UserId");
        }
    }
}