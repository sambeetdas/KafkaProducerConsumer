using Kafka.Manager.Contracts;
using Kafka.Manager.Implements;
using Listener.Manager.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .UseContentRoot(AppContext.BaseDirectory)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<IConsumerContract, ConsumerHandler>();
        services.AddHostedService<CustomerServiceListener>();
    })
    .Build();

host.Run();
