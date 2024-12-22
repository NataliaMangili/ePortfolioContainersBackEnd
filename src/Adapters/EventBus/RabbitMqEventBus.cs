using ePortfolio.Domain.Ports;
using ePortfolio.Domain.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EventBus;

public class RabbitMqEventBus : IEventBus
{
    private readonly RabbitMqConfiguration _config;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqEventBus(RabbitMqConfiguration config)
    {
        _config = config;

        ConnectionFactory factory = new()
        {
            HostName = _config.HostName,
            Port = _config.Port
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: _config.ExchangeName, type: ExchangeType.Fanout);
    }

    public void Publish<TEvent>(TEvent @event) where TEvent : IntegrationEventBase
    {
        var eventName = @event.GetType().Name;
        var message = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(
            exchange: _config.ExchangeName,
            routingKey: string.Empty,
            basicProperties: null,
            body: body
        );
    }
}