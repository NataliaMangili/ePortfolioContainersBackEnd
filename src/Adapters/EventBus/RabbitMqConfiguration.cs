namespace EventBus;

public class RabbitMqConfiguration
{
    public string HostName { get; set; }
    public int Port { get; set; } = 5672;
    public string ExchangeName { get; set; } = "EventBusExchange";
}
