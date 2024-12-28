namespace Application.Events;
public class EntityInsertedEvent<T>
{
    public EntityInsertedEvent(T entity)
    {
        Entity = entity;
    }
    public T Entity { get; }
}