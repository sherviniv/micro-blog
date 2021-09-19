using EventBus.Events.Base;

namespace EventBus.Events.Events
{
    public record BlogPublishedEvent : IntegrationEvent
    {
        public string PublisherUserId { get; set; }

        public BlogPublishedEvent(string publisher)
        {
            PublisherUserId = publisher;
        }
    }
}