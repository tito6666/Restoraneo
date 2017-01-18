using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Restoraneo.ViewModels
{
    public class RestaurantDashboardViewModel
    {
        public IPagedList<ReservationViewModel> Reservations  { get; set; }

        public  DashboardStatsViewModel DashboardStats { get; set; }

        public int RestaurantId { get; set; }
    }
}