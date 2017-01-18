using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Restoraneo.Models;
using Restoraneo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace Restoraneo.Hubs
{
    public class ReservationHub : Hub
    {
        ApplicationDbContext _context;
        public ReservationHub()
        {
            _context = new ApplicationDbContext();
        }

        public async Task SendClientReservation(ReservationClaim model)
        {
            var userNameRestaurant = _context.Users
               .Where(u => u.Restaurant.RestaurantId == model.RestaurantId)
               .Select(u => u.UserName).SingleOrDefault();
            var user = Context.User.Identity;
            model.ClientUsername = user.Name;
            model.ClientId = user.GetUserId();
            model.RestaurantName = userNameRestaurant;
            Clients.Group(model.ClientUsername);
            Clients.Group(userNameRestaurant);
            _context.ReservationClaim.Add(model);
            _context.SaveChanges();
            var countClaims = _context.ReservationClaim.Where(r => r.RestaurantId == model.RestaurantId).ToList();
            if (countClaims.Count() == 1)
            {
                var clientReservation = countClaims.Take(1).Where(r => r.RestaurantId == model.RestaurantId).SingleOrDefault();
                await Clients.Group(userNameRestaurant).addClientReservation(clientReservation);
            }

        }

        public async Task SendResponseToClient(ReservationClaim reservationClaim, string messagge)
        {
            Clients.Group(reservationClaim.ClientUsername).addClientResponse(messagge);
            var claimToRemove = _context.ReservationClaim.
                SingleOrDefault(i => i.ReservationClaimId 
                == reservationClaim.ReservationClaimId);
            _context.ReservationClaim.Remove(claimToRemove);
            _context.SaveChanges();
            var countClaims = _context.ReservationClaim.Where(r => r.RestaurantId == reservationClaim.RestaurantId).ToList();
            if (countClaims.Count() > 0)
            {
                var clientReservation = countClaims.Take(1).Where(r => r.RestaurantId == reservationClaim.RestaurantId).SingleOrDefault();
                await Clients.Caller.addClientReservation(clientReservation);
            }           
        }


        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }

    }
}