using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarWebApi.Services;

namespace CalendarWebApi.Gateway
{
    public class ProviderFactory
    {
    private readonly IHttpClientFactory _httpClientFactory;

        public ProviderFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public ISubscriptionProvider GetProvider(string platform)
        {
            return platform switch
            {
                "LaNacion" => new LaNacionProvider(_httpClientFactory.CreateClient("LaNacionClient")),
                _ => throw new ArgumentException("Plataforma no válida", nameof(platform))
            };
        }
    }
}