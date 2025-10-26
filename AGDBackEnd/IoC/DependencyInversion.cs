using Application.Interface.Data.Repository;
using Application.Interface.UseCase.Complaint;
using Application.Interface.UseCase.Partner;
using Application.UseCase.Complaint;
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
        //Partner
        services.AddScoped<IInsertPartnerCase, InsertPartnerCase>();
        services.AddScoped<IDeletePartnerCase, DeletePartnerCase>();
        services.AddScoped<IGetPartnerByEmailCase, GetPartnerByEmailCase>();

        //Complaint

        services.AddScoped<IInsertComplaintCase, InsertComplaintCase>();
    }
    public static void addRepository(this IServiceCollection services)
    {
        //Partner
        services.AddScoped<IPartnerRepository, PartnerRepository>();
        //Complaint
        services.AddScoped<IComplaintRepository, ComplaintRepository>();
    }

    public static void addDatabase(this IServiceCollection services) => services.AddScoped<DbSession>();
}
