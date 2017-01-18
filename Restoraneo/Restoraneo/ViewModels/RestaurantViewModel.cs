using Restoraneo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoraneo.ViewModels
{
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }

        public List<int> RestaurantIds { get; set; }
    }
}