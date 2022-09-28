using Kafka.Manager.Implements;

ConsumerHandler obj = new ConsumerHandler();
while (true)
{
    var result = obj.ConsumeCustomer("customer_topic");
}