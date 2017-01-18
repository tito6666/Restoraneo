using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoraneo.ViewModels
{
    public class RestaurantDetailsViewModel
    {
        public string RestaurantId { get; set; }

        public string Name { get; set; }      

        public string Lat { get; set; }

        public string Long { get; set; }

        public RestaurantInfoViewModel RestaurantInfo { get; set; }

        public List<RestaurantDishViewModel> Dishes { get; set; }
    }
}