using Restoraneo.Models;
using Restoraneo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Restoraneo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            var restaurants = db.Restaurants.ToList();

            if (restaurants.Count > 0)
            {
                ViewBag.restaurants = restaurants.Select(i => new SelectListItem { Text = i.Name, Value = i.RestaurantId.ToString() });
            }

            var model = new RestaurantViewModel
            {
                RestaurantIds = restaurants.Select(i => i.RestaurantId).ToList()
            };

            return View(model);
        }

        public ActionResult RestaurantDetails(int id)
        {
            var restaurants = db.Restaurants.Include(r => r.RestaurantDishes).ToList();
             
            if (restaurants.Count > 0)
            {
                ViewBag.restaurantsDetails = restaurants.Select(i => new SelectListItem { Text = i.Name, Value = i.RestaurantId.ToString() });
            }

            var restaurant = restaurants.SingleOrDefault(r => r.RestaurantId == id);
            var model = new RestaurantDetailsViewModel();

            model.RestaurantId = restaurant.RestaurantId.ToString();
            model.Name = restaurant.Name;
            model.Lat = restaurant.Lat.ToString().Replace(",", ".");
            model.Long = restaurant.Long.ToString().Replace(",", ".");
            model.RestaurantInfo = new RestaurantInfoViewModel
            {
                Address = restaurant.RestaurantInfo.Address,
                HoursOfWork = restaurant.RestaurantInfo.HoursOfWork,
                KitchenType = restaurant.RestaurantInfo.KitchenType,
                PaymentType = restaurant.RestaurantInfo.PaymentType,
                Telephone = restaurant.TelephoneNumber1
            };
            model.Dishes = new List<RestaurantDishViewModel>();
            model.Dishes = restaurant.RestaurantDishes.Select(d => new RestaurantDishViewModel
            {
                Name = d.Name,
                Description = d.Description,
                Price = d.Price
            }).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}