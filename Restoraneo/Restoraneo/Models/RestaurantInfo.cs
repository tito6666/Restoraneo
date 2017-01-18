using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoraneo.Models
{
    public class RestaurantInfo
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string KitchenType { get; set; }

        public string HoursOfWork { get; set; }

        public string PaymentType { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}