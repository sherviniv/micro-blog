using Microsoft.EntityFrameworkCore;
using Subscription.Application.Common.Interfaces;
using Subscription.Domain.Entities;
using System.Threading.Tasks;

namespace Subscription.Application.Services
{
    public class SubscriberService
    {
        private readonly ISubscriptionDbContext _context;

        public SubscriberService(ISubscriptionDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(string email)
        {
            Subscriber model = new (email);
            _context.Subscribers.Add(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<bool> DisableAsync(string email) 
        {
            var model = await _context.Subscribers.FirstOrDefaultAsync(c => c.Email.ToLower() == email.ToLower());
            if (model == null) 
            {
                //TODO:Handle me
            }
            model.IsActive = false;
            return true;
        }
    }
}