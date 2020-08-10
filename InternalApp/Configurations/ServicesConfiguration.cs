using BLL.Services.Abstract;
using BLL.Services.Implementation;
using DAL.Context;
using DAL.Repositories.Abstract;
using DAL.Repositories.Implementation;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternalApp.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureDataAccessServices(this IServiceCollection services)
        {
            // DAL
            services.AddSingleton<DbContext, InternalAppContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            // BLL
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IFileService, CSVFileService>();
        }
    }
}
