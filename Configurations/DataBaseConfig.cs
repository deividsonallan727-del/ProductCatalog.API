using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Model.Context;

namespace ProductCatalog.API.Configurations
{
    public static class DataBaseConfig
    {//se nao criasse isso aqui nessa classe teria que criar tudo apartir da var ConnectionString no program, oq deixaria tudo mais verboso
        public static IServiceCollection addDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLConnection:MSSQLConnectionString"];//busco do json
            if(string.IsNullOrEmpty(connectionString))//caso nao seja encontrada lanca essa excessao
            {
                throw new ArgumentNullException("Connection string 'MSSQLConnectionString' not found");
            }

            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
