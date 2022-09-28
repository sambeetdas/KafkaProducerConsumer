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
                //BootstrapServers = configuration["Kafka:BootStrapServer"]
                BootstrapServers = "localhost:9092"
            };

            dynamic cr;
            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe(topic);
                cr = consumer.Consume();                
            }
            var customer = JsonSerializer.Deserialize<CustomerModel>(cr.Message.Value);
            return customer;
        }
    }
}
