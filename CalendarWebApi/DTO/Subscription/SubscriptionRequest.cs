namespace CalendarWebApi
{
    using System.ComponentModel.DataAnnotations;

    public class SubscriptionRequest
    {
        [Required]
        public string? Platform { get; set; }
        public int? Dni { get; set; }

        [StringLength(16, MinimumLength = 16, ErrorMessage = "La credencial debe tener 16 dígitos.")]
        public string? Credencial { get; set; }
    }
}