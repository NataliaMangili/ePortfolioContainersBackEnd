using ePortfolio.Domain.Events;

namespace ePortfolio.Domain.Ports;

public interface IEventBus
{
    void Publish<TEvent>(TEvent @event) where TEvent : IntegrationEventBase;
}