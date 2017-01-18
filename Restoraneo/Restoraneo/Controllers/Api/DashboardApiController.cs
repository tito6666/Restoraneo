using Microsoft.AspNet.Identity;
using Restoraneo.Dtos;
using Restoraneo.Models;
using Restoraneo.ViewModels;
using System;
using System.Linq;
using System.Web.Http;

namespace Restoraneo.Controllers.Api
{
    [Authorize]
    public class DashboardApiController : ApiController
    {
        private ApplicationDbContext context;
        public DashboardApiController()
        {
           context = new ApplicationDbContext();
        }
        // GET: DashboardApi
        public IHttpActionResult GetDashboardStats(string stDate, string enDate, string restId)
        {
            if (string.IsNullOrEmpty(stDate) || string.IsNullOrEmpty(enDate) || string.IsNullOrEmpty(restId))
            {
                return BadRequest();
            }
            int restaurantId = int.Parse(restId);
            DateTime startDate = Convert.ToDateTime(stDate);
            DateTime endDate = Convert.ToDateTime(enDate);
            var reservations = context.Reservations
                      .Where(r => r.RestaurantId == restaurantId
                      && (r.DateTimeOfReservation >= startDate
                      && r.DateTimeOfReservation <= endDate))
                      .ToList();

            DashboardStatsViewModel model = new DashboardStatsViewModel();
            model.NumOfReservations = reservations.Count();
            model.NumOfConfirmedReservations = reservations.Where(r => r.ReservationStatus == 0).Count();
            model.NumOfUsedReservations = reservations.Where(r => r.ReservationStatus == 1).Count();
            model.NumOfCanceledReservations = reservations.Where(r => r.ReservationStatus == 2).Count();
            model.NumOfReservaitedSeats = reservations.Select(r => r.NumberOfPersons).Sum();
            model.NumOfUsers = reservations.Select(r => r.ApplicationUser_Id).Distinct().Count();
            
            return Json(model);
        }
    }
}