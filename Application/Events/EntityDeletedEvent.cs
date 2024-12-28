namespace Application.Events;

public class EntityDeletedEvent<T>
{    
    public EntityDeletedEvent(T entity)
    {
        Entity = entity;
    }
    public T Entity { get; }
}