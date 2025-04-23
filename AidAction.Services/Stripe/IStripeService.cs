using Stripe.Checkout;
using Stripe.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Services.Stripe
{
    public interface IStripeService
    {
        Task<string> CreateCheckoutSession(decimal amount,int? campaignId,int? needId);
        Task<Session> GetCheckoutSession(string sessionId);
    }
}
