using System;

namespace Restoraneo.ViewModels
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }

        public string UserId { get; set; }

        public string RestaurantName { get; set; }

        public int NumberOfPersons { get; set; }

        [FutureDate]
        public string DateOfReservation { get; set; }

        [ValidTime]
        public string TimeOfReservation { get; set; }

        public int RestaurantId { get; set; }

        public string Username { get; set; }

        public string UserMobilePhone { get; set; }

        public int ReservationStatus { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", DateOfReservation, TimeOfReservation));
        }
    }
}