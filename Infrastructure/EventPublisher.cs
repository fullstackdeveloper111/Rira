using Application.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EventPublisher : IEventPublisher
    {
        public virtual async Task PublishAsync<TEvent>(TEvent @event)
        {
            var consumers = ResolveAll<TEvent>().ToList();

            foreach (var consumer in consumers)
            {
                try
                {
         
                    await consumer.HandleEventAsync(@event);
                }
                catch (Exception exception)
                {
         
                    try
                    {
                        var logger = EngineContext.Current.Resolve<ILogger>();
                        if (logger == null)
                            return;

                        await logger.ErrorAsync(exception.Message, exception);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        
        public virtual void Publish<TEvent>(TEvent @event)
        {
            
            var consumers = ResolveAll<TEvent>().ToList();

            foreach (var consumer in consumers)
                try
                {
                    consumer.HandleEventAsync(@event).Wait();
                }
                catch (Exception exception)
                {
                    try
                    {
                        var logger = EngineContext.Current.Resolve<ILogger>();
                        if (logger == null)
                            return;

                        logger.Error(exception.Message, exception);
                    }
                    catch
                    {
                    }
                }
        }


        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }
        public virtual IServiceProvider ServiceProvider { get; protected set; }
        protected virtual IServiceProvider GetServiceProvider(IServiceScope scope = null)
        {
            if (scope == null)
            {
                var accessor = ServiceProvider?.GetService<IHttpContextAccessor>();
                var context = accessor?.HttpContext;
                return context?.RequestServices ?? ServiceProvider;
            }
            return scope.ServiceProvider;
        }
    }
}
