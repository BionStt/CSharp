using FluentNHibernate.Mapping;

namespace Examples
{
    public class UserLogMap : ClassMap<UserLog>
    {
        public UserLogMap()
        {
            Schema("[User]");
            Table("[UsersLogs]");
            LazyLoad();
            Id(x => x.UserLogId).GeneratedBy.Identity().Column("UserLogId");
            References(x => x.Users).Column("UserId");
            Map(x => x.Datetime).Column("DateTime").Not.Nullable();
            Map(x => x.LogType).Column("LogType").Not.Nullable().Precision(10);
            Map(x => x.Message).Column("Message").Length(8000);
        }
    }
}