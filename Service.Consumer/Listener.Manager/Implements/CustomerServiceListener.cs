using Kafka.Manager.Contracts;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listener.Manager.Implements
{
    public class CustomerServiceListener : BackgroundService
    {
        private readonly IConsumerContract _consumerHandler;
        public CustomerServiceListener(IConsumerContract consumerHandler)
        {
            _consumerHandler = consumerHandler;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                Task.Run(() => _consumerHandler.ConsumeCustomer(stoppingToken));
               
            }
            catch (Exception)
            {
                throw;
            }

            return Task.CompletedTask;
        }
    }
}
