using System;
namespace TickTick.Api
{
	public static class IOCExtentions
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
            services.AddTransient<IPersonsService, PersonsService>();
        }
	}
}

