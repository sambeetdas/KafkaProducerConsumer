using Confluent.Kafka;
using Entity.Manager.Customer;
using Kafka.Manager.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kafka.Manager.Implements
{
    public class ProducerHandler : IProducerContract
    {
        private IConfiguration _configuration { get; set; }
        public ProducerHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CustomerModel> ProduceCustomer(CustomerModel customer)
        {
            try
            {
                customer.Topic = _configuration["Kafka:Topic"];
                var config = new ProducerConfig()
                {
                    BootstrapServers = _configuration["Kafka:BootStrapServer"],
                    Acks = Acks.None
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    await producer.ProduceAsync(customer.Topic, new Message<Null, string> { Value = JsonSerializer.Serialize<CustomerModel>(customer) });
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return customer;
        }
    }
}
