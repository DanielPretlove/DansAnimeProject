using AnimeList.Application.Mappers;
using AnimeList.Application.Services;
using AnimeList.Application.Services.AnimeList;
using AnimeList.Data.Access;
using AnimeList.Data.Access.Repositories;
using AnimeList.Data.Access.Repositories.AnimeList;
using AnimeList.Data.Access.Repositories.AnimeSeason;
using Microsoft.EntityFrameworkCore;

namespace AnimeList.Web.Server
{
    public static class ServiceRegistry
    {
        public static IServiceCollection ServiceRegistryContainer(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<AnimeService>();
            services.AddScoped<SeasonService>();
            services.AddScoped(typeof(IAnimeRepository), typeof(AnimeRepository));
            services.AddScoped(typeof(ISeasonRepository), typeof(SeasonRepository));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped(typeof(AutoMapper.Mapper));
            services.AddDbContext<ApplicationDataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DansAnimeList"), m => m.MigrationsAssembly("AnimeList.Data.Access"));
            });

            return services;

        }
    }
}
