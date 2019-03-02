using FastMapper;

public class FastMapper
{
	public FastMapper()
	{
		//TypeAdapterConfig<TSource, TDestination>.NewConfig().MapFrom(d => d.Property, s => s.Property);
	}

	public TDestination Map<TDestination>(object source)
	{
		return TypeAdapter.Adapt<TDestination>(source);
	}

	public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
	{
		TypeAdapterConfig<TSource, TDestination>.NewConfig().IgnoreNullValues(true).MaxDepth(3);
		return TypeAdapter.Adapt(source, destination);
	}
}