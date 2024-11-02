using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarWebApi.DTO.Subscription
{
    public class SubscriptionResponse
    {
        public int? Id { get; set; }
        public int? Code { get; set; }
        public bool IsValid { get; set; }
        public string? Message { get; set; }
    }

}