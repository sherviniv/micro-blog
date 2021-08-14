using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Common.Models
{
    public record ConsumerDetail
    {
        public string QueueName { get; set; }
        public List<Type> Consumers { get; set; }
    }
}
