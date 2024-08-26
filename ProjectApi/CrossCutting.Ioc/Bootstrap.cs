using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Base;
using Infrastructure.Context;
using Infrastructure.Repository;
using Domain.Interfaces.IRepository;
using System.Data;
using System.Reflection;

namespace CrossCutting.Ioc
{
    public static class Bootstrap
    {
        private const string APPLICATION_NAMESPACE = "Application";


        public static void AddMediatorServices(this IServiceCollection services)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Command<>).GetTypeInfo().Assembly));
        }

        public static void AddIoCServices(this IServiceCollection services)
        {

            services.AddTransient<ITaskRepository, TaskRepository>();

        }

        public static IServiceCollection AddSqlServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MyTask");

            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddDbContextPool<MyTasksDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")));



            return services;
        }



    }
}
