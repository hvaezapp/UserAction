using UserAction.DbContexts.Sql.SqlServer;
using Microsoft.EntityFrameworkCore;
using MassTransit;

namespace UserAction.Registeration
{
    public static class RegisterDependency
    {
        public static void RegisterSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserActionContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));

            }, ServiceLifetime.Scoped);
        }


        public static IServiceCollection RegisterBroker(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration.GetValue<string>("BrokerConfiguration:Host") ?? throw new ArgumentNullException("hostname must valid");
            var username = configuration.GetValue<string>("BrokerConfiguration:UserName") ?? throw new ArgumentNullException("username must valid");
            var password = configuration.GetValue<string>("BrokerConfiguration:Password") ?? throw new ArgumentNullException("password must valid");

            services.AddMassTransit(configure =>
            {
                configure.AddConsumers(typeof(Program).Assembly);

                configure.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseRawJsonDeserializer();

                    cfg.Host(host, hostConfigure =>
                    {
                        hostConfigure.Username(username);
                        hostConfigure.Password(password);
                    });

                    cfg.ConfigureEndpoints(context);
                });

            });

            return services;
        }

    }




}
