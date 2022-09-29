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
    public class ConsumerHandler : IConsumerContract
    {
        private IConfiguration _configuration { get; set; }

        public ConsumerHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CustomerModel> ConsumeCustomer()
        {
            string topic = "customer-topic"; //_configuration["Kafka:Topic"]
            string groupId = topic + "-consumer-group";
            string bootstrapServer = "localhost:9092"; //_configuration["Kafka:BootStrapServer"]
            var config = new ConsumerConfig()
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServer,
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            dynamic customerMessage = null;
            try
            {
                using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
                {
                    consumer.Subscribe(topic);
                    var cr = consumer.Consume();
                    if (cr.Message != null)
                        customerMessage = JsonSerializer.Deserialize<CustomerModel>(cr.Message.Value);

                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return customerMessage;
        }
    }
}
