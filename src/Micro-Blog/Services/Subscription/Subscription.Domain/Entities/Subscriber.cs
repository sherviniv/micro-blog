using System;
using System.ComponentModel.DataAnnotations;

namespace Subscription.Domain.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        public DateTime Created { get;}
        public bool IsActive { get; set; }

        public Subscriber()
        {
            Created = DateTime.Now;
            IsActive = true;
        }

        public Subscriber(string email)
        {
            Email = email;
            Created = DateTime.Now;
            IsActive = true;
        }
    }
}
