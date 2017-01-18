using Microsoft.AspNet.Identity;
using PagedList;
using Restoraneo.Models;
using Restoraneo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restoraneo.Controllers
{

    [Authorize(Roles = "Admin restaurant")]
    public class DashboardHomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: DashboardHome
        public ActionResult Index(string sortOrder, string currentFilter, string query, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

                if (query != null)
                {
                    page = 1;
                }
                else
                {
                    query = currentFilter;
                }

            ViewBag.CurrentFilter = query;

            var userId = User.Identity.GetUserId();
            var user = context.Users.Where(u => u.Id == userId)
                .FirstOrDefault();
            var reservationsDb = new List<Reservation>();
            if (!String.IsNullOrEmpty(query))
            {
                reservationsDb = context.Reservations
                        .Where(r => r.RestaurantId == user.Restaurant.RestaurantId
                        && r.ApplicationUser.UserName.Contains(query))
                        .ToList();
            }
            else
            {
                switch (sortOrder)
                {
                    case "Date":
                        reservationsDb = context.Reservations
                            .Where(r => r.RestaurantId == user.Restaurant.RestaurantId)
                            .OrderBy(r => r.DateTimeOfReservation)
                            .ToList();
                        break;
                    case "date_desc":
                        reservationsDb = context.Reservations
                            .Where(r => r.RestaurantId == user.Restaurant.RestaurantId)
                            .OrderByDescending(r => r.DateTimeOfReservation)
                            .ToList();
                        break;
                    default:                      
                        reservationsDb = context.Reservations
                        .Where(r => r.RestaurantId == user.Restaurant.RestaurantId)
                        .ToList();                      
                        break;
                }
            }
                        
                ViewBag.RestaurantName = context.Restaurants
                .Where(r => r.RestaurantId == user.Restaurant.RestaurantId).Select( r=> r.Name).SingleOrDefault();
           
            var reservationsList = new List<ReservationViewModel>();
           if (reservationsDb.Count() > 0)
            {
                reservationsList = reservationsDb.Select(r => new ReservationViewModel
                {
                    ReservationId = r.ReservationId,
                    NumberOfPersons = r.NumberOfPersons,
                    DateOfReservation = r.DateTimeOfReservation.ToString("dd.MM.yyyy."),
                    TimeOfReservation = r.DateTimeOfReservation.ToString("HH:mm"),
                    Username = r.ApplicationUser.UserName,
                    UserMobilePhone = r.ApplicationUser.PhoneNumber,
                    ReservationStatus = r.ReservationStatus,
                    RestaurantId = r.RestaurantId
                }).ToList();
            
             } 
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            RestaurantDashboardViewModel model = new RestaurantDashboardViewModel();
            model.DashboardStats = GetAllStatsById(user.Restaurant.RestaurantId);
            model.RestaurantId = user.Restaurant.RestaurantId;
            model.Reservations = reservationsList.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        public DashboardStatsViewModel GetAllStatsById(int id)
        {
            var startDate = DateTime.Now.AddDays(-30);
              var  reservations = context.Reservations
                        .Where(r => r.RestaurantId == id 
                        && (r.DateTimeOfReservation >= startDate
                        && r.DateTimeOfReservation <= DateTime.Now))
                        .ToList();
           
            DashboardStatsViewModel model = new DashboardStatsViewModel();
            model.NumOfReservations = reservations.Count();
            model.NumOfConfirmedReservations = reservations.Where(r => r.ReservationStatus == 0).Count();
            model.NumOfUsedReservations = reservations.Where(r => r.ReservationStatus == 1).Count();
            model.NumOfCanceledReservations = reservations.Where(r => r.ReservationStatus == 2).Count();
            model.NumOfReservaitedSeats = reservations.Select(r => r.NumberOfPersons).Sum();
            model.NumOfUsers = reservations.Select(r => r.ApplicationUser_Id).Distinct().Count();

            return model;
        }
    }
  }
