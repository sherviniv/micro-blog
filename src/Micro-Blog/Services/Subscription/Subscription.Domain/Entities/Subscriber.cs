using System;
using System.ComponentModel.DataAnnotations;

namespace Subscription.Domain.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
    }
}
