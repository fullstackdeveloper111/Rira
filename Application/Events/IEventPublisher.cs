namespace Application.Events;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent @event);
    void Publish<TEvent>(TEvent @event);
}
