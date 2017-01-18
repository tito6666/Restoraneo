using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoraneo.ViewModels
{
    public class DashboardStatsViewModel
    {
        public int NumOfReservations { get; set; }

        public int NumOfUsedReservations { get; set; }

        public int NumOfConfirmedReservations { get; set; }

        public int NumOfCanceledReservations { get; set; }

        public int NumOfUsers { get; set; }

        public int NumOfReservaitedSeats { get; set; }
    }
}