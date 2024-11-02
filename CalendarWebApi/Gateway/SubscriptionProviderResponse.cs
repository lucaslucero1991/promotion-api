using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarWebApi.Models
{
    public class SubscriptionProviderResponse
    {
        public bool IsValid { get; set; }
        public string? Message { get; set; }
        public int? Code { get; set; } // Opcional, para incluir códigos personalizados de los proveedores
        public string? Card { get; set; }
    }
}