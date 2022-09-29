using Confluent.Kafka;
using Entity.Manager.Customer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kafka.Manager.Implements
{   
    public class ConsumerHandler
    {

        public async Task<CustomerModel> ConsumeCustomer(string topic)
        {

            //IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            //                .Build();

            var config = new ConsumerConfig()
            {
                GroupId = topic + "-consumer-group",
                //BootstrapServers = configuration["Kafka:BootStrapServer"]
                BootstrapServers = "localhost:9092",
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
