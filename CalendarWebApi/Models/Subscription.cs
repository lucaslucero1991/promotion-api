using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarWebApi.Models
{
    public class Subscription
    {
        public string Platform { get; set; }
        public int? Dni { get; set; }
        public string? Card { get; set; }

        public Subscription(string platform, int? dni, string? card)
        {
            Platform = platform;
            Dni = dni;
            Card = card;
        }
    }

}