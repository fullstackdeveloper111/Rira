using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events
{
    public interface IConsumer<T>
    {
        Task HandleEventAsync(T eventMessage);
    }
}
