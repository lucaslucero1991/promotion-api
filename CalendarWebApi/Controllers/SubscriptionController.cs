

using System.ComponentModel.DataAnnotations;
using CalendarWebApi.Controllers.Validators;
using CalendarWebApi.DTO.Subscription;
using CalendarWebApi.Models;
using CalendarWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalendarWebApi.Controllers
{
    public interface IValidator
    {
        ValidationResult Validate(SubscriptionRequest request);
    }

    public interface ISubscriptionService
    {
        Task<SubscriptionResponse> ValidateSubscription(Subscription request);
    }

    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly ValidatorFactory _validatorFactory;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
            _validatorFactory = new ValidatorFactory();
        }

        [HttpPost]
        public async Task<IActionResult> ValidateSubscription([FromBody] SubscriptionRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Platform))
            {
                return BadRequest("Request body is null");
            }

            try
            {
                var validator = _validatorFactory.GetValidator(request.Platform);
                var validationResult = validator.Validate(request);

                if (validationResult != ValidationResult.Success)
                {
                    return BadRequest(validationResult.ErrorMessage);
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            var result = await _subscriptionService.ValidateSubscription(new Subscription(
                platform: request.Platform,
                dni: request.Dni,
                card: request.Credencial
            ));

            return result.IsValid ? Ok(result) : StatusCode(result.Code ?? 500, result.Message);
        }
    }
}