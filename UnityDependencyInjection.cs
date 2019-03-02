using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.RegistrationByConvention;

public static class UnityDependencyInjection
{
	private static IUnityContainer _container;

	public static IUnityContainer Container
	{
		get
		{
			if (_container != null) { return _container; }
			_container = new UnityContainer();
			_container.RegisterTypes(Types, WithMappings.FromAllInterfacesInSameAssembly, WithName.Default, WithLifetime.ContainerControlled);
			return _container;
		}
	}

	private static IEnumerable<Type> Types =>
		AllClasses.FromLoadedAssemblies().Where(x => !string.IsNullOrWhiteSpace(x.Namespace) && x.Namespace.StartsWith("Namespace"));
}