using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;
using Stripe.Checkout;
using AidAction.Domain.DomainModels.Auth;
using Microsoft.Extensions.Options;
namespace AidAction.Services.Stripe
{

    public class StripeService : IStripeService
    {
        private readonly string _secretKey;

        public StripeService(IOptions<StripeSettings> stripeSettings)
        {
            _secretKey = stripeSettings.Value.SecretKey;
            StripeConfiguration.ApiKey = _secretKey;
        }

        public async Task<string> CreateCheckoutSession(decimal amount, int? campaignId, int? needId)
        {
            // Create a Product (if you don't have one already)
            var productOptions = new ProductCreateOptions
            {
                Name = "Donation",  // Product name
                Description = "Charitable donation",  // Optional description
            };

            var productService = new ProductService();
            Product product = productService.Create(productOptions);

            var priceOptions = new PriceCreateOptions
            {
                UnitAmount = (long)(amount * 100), // amount in cents
                Currency = "usd",
                ProductData = new PriceProductDataOptions
                {
                    Name = "Donation",  // Product name
                }
            };

            var priceService = new PriceService();
            Price price = priceService.Create(priceOptions);

            // Create the Checkout Session with the Price
            var sessionOptions = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = price.Id,  // Use the price ID here
                    Quantity = 1,
                },
            },
                Mode = "payment",
                SuccessUrl = $"https://localhost:44398/MainWebsite/SuccessDonation?session_id={{CHECKOUT_SESSION_ID}}&needId={needId}&campaignId={campaignId}",
                CancelUrl = $"https://localhost:44398/MainWebsite/SuccessDonation?session_id={{CHECKOUT_SESSION_ID}}&needId={needId}&campaignId={campaignId}",


                //SuccessUrl = $"http://aidaction-001-site1.mtempurl.com/MainWebsite/SuccessDonation?session_id={{CHECKOUT_SESSION_ID}}&needId={needId}&campaignId={campaignId}",
                //CancelUrl = $"http://aidaction-001-site1.mtempurl.com/SuccessDonation?session_id={{CHECKOUT_SESSION_ID}}&needId={needId}&campaignId={campaignId}",

                ExpiresAt = DateTime.UtcNow.AddMinutes(30) // Set expiration to 2 hours from now (you can change this duration)


            };

            try
            {
                var sessionService = new SessionService();
                Session session = await sessionService.CreateAsync(sessionOptions);
                return session.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }


        public string CreatePaymentIntent(decimal amount)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),  // amount in cents
                Currency = "usd",
                // Optionally you can add more options like receipt_email or metadata
            };



            var service = new PaymentIntentService();


            try
            {
                var paymentIntent = service.Create(options);
                return paymentIntent.ClientSecret;
            }
            catch (StripeException ex)
            {
                // Log the exception details
                Console.WriteLine($"Stripe error: {ex.Message}");
                throw; // rethrow the error if needed or handle it accordingly
            }

        }

        public async Task<Session> GetCheckoutSession(string sessionId)
        {
            var sessionService = new SessionService();
            Session session = await sessionService.GetAsync(sessionId);
            return session;
        }


    }


}

