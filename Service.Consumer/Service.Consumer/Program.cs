using Kafka.Manager.Contracts;
using Kafka.Manager.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Consumer;

IHost host = Host.CreateDefaultBuilder(args)
    .UseContentRoot(AppContext.BaseDirectory)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<IConsumerContract, ConsumerHandler>();
        services.AddHostedService<ServiceHost>();
    })
    .Build();

host.Run();
