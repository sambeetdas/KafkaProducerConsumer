using Kafka.Manager.Contracts;
using Kafka.Manager.Implements;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Consumer
{
    public class ServiceHost : IHostedService
    {
        private readonly IConsumerContract _consumerHandler;
        public ServiceHost(IConsumerContract consumerHandler)
        {
            _consumerHandler = consumerHandler;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (true)
                {
                    var message = await _consumerHandler.ConsumeCustomer();
                    if (message != null)
                    {
                        Console.WriteLine(message.Name);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            //return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
