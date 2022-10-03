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
        public async Task ConsumeCustomer(CancellationToken stoppingToken)
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

            try
            {
                using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
                {
                    consumer.Subscribe(topic);

                    while (!stoppingToken.IsCancellationRequested)
                    {                        
                        var consumedMessage = consumer.Consume();

                        if (consumedMessage != null && consumedMessage.Message != null)
                            await ProcessConsumedData(consumedMessage);
                    }

                    consumer.Close();
                }                
            }
            catch (Exception)
            {
                throw;
            }           
        }

        private async Task ProcessConsumedData(dynamic consumedMessage)
        {
            var result = JsonSerializer.Deserialize<CustomerModel>(consumedMessage.Message.Value);
            if (result != null)
            {
                Console.WriteLine(result.Name);
            }           
        }
    }
}
