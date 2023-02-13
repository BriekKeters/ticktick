using System;
using MediatR;
using TickTick.Api.Services;
using TickTick.Models;
using TickTick.Repositories;
using TickTick.Repositories.Base;

namespace TickTick.Api
{
	public static class IOCExtentions
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
            services.AddTransient<IPersonsService, PersonsService>();
			services.AddTransient<IRepository<Person>, Repository<Person>>();
			services.AddTransient<ISongService, SongService>();
			services.AddTransient<IRepository<PlaylistItem>, Repository<PlaylistItem>>();

			services.AddMediatR(System.Reflection.Assembly.GetAssembly(typeof(IOCExtentions)));
        }
	}
}

