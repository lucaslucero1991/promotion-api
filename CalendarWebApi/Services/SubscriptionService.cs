using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarWebApi.Controllers;
using CalendarWebApi.DTO.Subscription;
using CalendarWebApi.Models;


namespace CalendarWebApi.Services
{
    public interface ISubscriptionGateway
    {
        Task<SubscriptionProviderResponse> ValidateSubscriptionAsync(string platform, int? dni, string? card);
    }

    public class SubscriptionService : ISubscriptionService
    {
       private readonly ISubscriptionGateway _subscriptionGateway;

        public SubscriptionService(ISubscriptionGateway subscriptionGateway)
        {
            _subscriptionGateway = subscriptionGateway;
        }

        public async Task<SubscriptionResponse> ValidateSubscription(Subscription request)
        {
            var gatewayResponse = await _subscriptionGateway.ValidateSubscriptionAsync(request.Platform, request.Dni, request.Card);

            return new SubscriptionResponse
            {
                Code = gatewayResponse.Code,
                IsValid = gatewayResponse.IsValid,
                Message = gatewayResponse.Message
            };
        }
    }                               
}