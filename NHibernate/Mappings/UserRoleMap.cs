using FluentNHibernate.Mapping;

namespace Examples
{
    public class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Schema("[User]");
            Table("[UsersRoles]");
            LazyLoad();
            CompositeId().KeyProperty(x => x.UserId, "UserId").KeyProperty(x => x.Role, "Role");
            References(x => x.Users).Column("UserId");
        }
    }
}