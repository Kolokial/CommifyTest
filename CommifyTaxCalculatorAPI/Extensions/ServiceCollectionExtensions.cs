using CommifyTaxCalculatorAPI.Data;
using Microsoft.EntityFrameworkCore;

public static class ServiceCollectionExtension
{
    public static void SetupDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TaxCalculatorDatabaseContext>(options =>
            options.UseSqlite(connectionString)
        );
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}
