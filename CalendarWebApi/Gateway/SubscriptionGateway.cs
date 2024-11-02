using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarWebApi.Models;
using CalendarWebApi.Services;

namespace CalendarWebApi.Gateway
{
    public interface ISubscriptionProvider
    {
        Task<SubscriptionProviderResponse> ValidateSubscriptionAsync(int? dni, string? card);
    }

    public class SubscriptionGateway : ISubscriptionGateway
    {
        private readonly ProviderFactory _providerFactory;

        public SubscriptionGateway(ProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
        }

        public async Task<SubscriptionProviderResponse> ValidateSubscriptionAsync(string platform, int? dni, string? card)
        {
            var provider = _providerFactory.GetProvider(platform);
            return await provider.ValidateSubscriptionAsync(dni, card);
        }
    }
}