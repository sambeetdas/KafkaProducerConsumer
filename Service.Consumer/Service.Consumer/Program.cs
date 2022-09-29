using Kafka.Manager.Implements;

ConsumerHandler obj = new ConsumerHandler();
try
{
    while (true)
    {
        var message = obj.ConsumeCustomer("customer-topic");
        if (message != null && message.Result != null)
        {
            Console.WriteLine(message.Result.Name);
        }
    }
}
catch (Exception)
{
	throw;
}
