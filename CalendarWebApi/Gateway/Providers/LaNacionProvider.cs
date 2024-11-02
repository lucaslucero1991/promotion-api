using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarWebApi.Models;
using CalendarWebApi.Services;
using Newtonsoft.Json;

namespace CalendarWebApi.Gateway
{
   public class LaNacionProvider : ISubscriptionProvider
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "6ygbD92yNj6caRkL2zqiZ5gWpNizswTR7soRxe61"; // Mueve este valor a la configuración

    public LaNacionProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SubscriptionProviderResponse> ValidateSubscriptionAsync(int? dni, string? card)
    {
        var requestUri = $"https://qa-clnvalidaciones.lanacion.com.ar/api/subscribers?dni={dni}&card={card}";
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        request.Headers.Add("x-api-key", _apiKey);

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = JsonConvert.DeserializeObject<LaNacionApiResponse>(content);
            return apiResponse.Code == 0
                ? new SubscriptionProviderResponse { IsValid = true, Message = apiResponse.Message, Card = apiResponse.Card }
                : new SubscriptionProviderResponse { IsValid = false, Message = apiResponse.Message, Code = apiResponse.Code };
        }

        // Manejo de errores según el código HTTP
        return response.StatusCode switch
        {
            System.Net.HttpStatusCode.BadRequest => new SubscriptionProviderResponse
            {
                IsValid = false,
                Message = System.Net.HttpStatusCode.BadRequest.ToString()
            },
            System.Net.HttpStatusCode.Unauthorized => new SubscriptionProviderResponse
            {
                IsValid = false,
                Message = System.Net.HttpStatusCode.Unauthorized.ToString()
            },
            System.Net.HttpStatusCode.Forbidden => new SubscriptionProviderResponse
            {
                IsValid = false,
                Message = System.Net.HttpStatusCode.Forbidden.ToString()
            },
            System.Net.HttpStatusCode.InternalServerError => new SubscriptionProviderResponse
            {
                IsValid = false,
                Message = System.Net.HttpStatusCode.InternalServerError.ToString()
            },
            _ => new SubscriptionProviderResponse
            {
                IsValid = false,
                Message = System.Net.HttpStatusCode.InternalServerError.ToString("unknow error")
            }
        };
    }
}

    public class LaNacionApiResponse
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public string? Card { get; set; }
        public string? Program { get; set; }
    }
}