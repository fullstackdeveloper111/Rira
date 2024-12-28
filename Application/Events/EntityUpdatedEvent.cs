namespace Application.Events;
public class EntityUpdatedEvent<T>
{    
    public EntityUpdatedEvent(T entity)
    {
        Entity = entity;
    }
    public T Entity { get; }
}