using kutya_sajat_api.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace kutya_sajat_api.Data.Repositories
{
    public static class RepositoryBuilder
    {
        public static IServiceCollection BuildRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<Repository<Breed>>()
                .AddScoped<Repository<MedicalRecord>>()
                .AddScoped<Repository<Owner>>()
                .AddScoped<Repository<Animal>>();
        }
    }
}
