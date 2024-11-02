using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarWebApi.Controllers
{
    public class LaNacionValidator : IValidator
    {
        public ValidationResult Validate(SubscriptionRequest request)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(request);

            if (!Validator.TryValidateObject(request, context, results, true))
            {
                return new ValidationResult(string.Join("; ", results.Select(r => r.ErrorMessage)));
            }

            if (request.Dni.HasValue && (request.Dni < 1000000 || request.Dni > 99999999))
            {
                return new ValidationResult("El DNI debe estar entre 1000000 y 99999999.");
            }

            return ValidationResult.Success!;
        }
    }

}