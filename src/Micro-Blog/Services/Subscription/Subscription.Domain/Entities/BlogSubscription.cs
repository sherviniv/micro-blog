using Subscription.Domain.Enum;

namespace Subscription.Domain.Entities
{
    public class BlogSubscription
    {
        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
        public SubscriptionType Subscription { get; set; }

        //tagid or userid and etc...
        public string SubscriptionValue { get; set; }
    }
}
