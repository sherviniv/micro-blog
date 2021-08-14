using MassTransit;

namespace EventBus.Common.Abstractions
{
    public interface IEventConsumer<T> : IConsumer<T> where T : class
    {
    }
}
