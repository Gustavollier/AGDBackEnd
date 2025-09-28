using Application.Interface.Data.Repository;
using Application.Interface.UseCase.Partner;
using Application.UseCase.Partner;
using Infrastructure.Data;
using Infrastructure.Data.Repository;

namespace AGDBackEnd.IoC;
public static class DependencyInversion
{
    public static void addIoC(this IServiceCollection services)
    {
        services.addUseCases();
        services.addRepository();
        services.addDatabase();
    }

    public static void addUseCases(this IServiceCollection services)
    {
        services.AddScoped<IInsertPartnerCase, InsertPartnerCase>();
    }
    public static void addRepository(this IServiceCollection services)
    {
        services.AddScoped<IPartnerRepository, PartnerRepository>();
    }

    public static void addDatabase(this IServiceCollection services)
    {
        services.AddScoped<DbSession>();
    }
}
