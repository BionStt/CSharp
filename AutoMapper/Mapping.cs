using AutoMapper;

namespace Examples
{
    public static class Mapping
    {
        public static void Initialize()
        {
            Mapper.Initialize(x => { x.AddProfiles(typeof(Mapping).Assembly.FullName); });
            Mapper.AssertConfigurationIsValid();
        }

        public static TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }

    public class MappingModelToTableProfile : Profile
    {
        public MappingModelToTableProfile()
        {
            this.IgnoreUnmapped();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();

            CreateMap<AdressTable, AddressModel>();
            CreateMap<UserTable, UserModel>();
        }
    }

    public class MappingTableToModelProfile : Profile
    {
        public MappingTableToModelProfile()
        {
            this.IgnoreUnmapped();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();

            CreateMap<AddressModel, AdressTable>();
            CreateMap<UserModel, UserTable>();
        }
    }
}