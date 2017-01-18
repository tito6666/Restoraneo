using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Restoraneo.Models;
using Microsoft.AspNet.Identity;
using Restoraneo.ViewModels;

namespace Restoraneo.Controllers.Api
{
    [Authorize]
    public class ReservationsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ReservationsApi
        public IQueryable<Reservation> GetReservations()
        {
            return db.Reservations;
        }

        // GET: api/ReservationsApi/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult GetReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/ReservationsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.ReservationId)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReservationsApi
        public IHttpActionResult PostReservation(ReservationViewModel reservationVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!User.Identity.IsAuthenticated)
                return BadRequest("Morate se prijaviti!");

            var reservation = new Reservation();

            reservation.DateTimeOfReservation = reservationVm.GetDateTime();
            reservation.NumberOfPersons = reservationVm.NumberOfPersons;
            reservation.RestaurantId = reservationVm.RestaurantId;
            reservation.ApplicationUser_Id = reservationVm.UserId;
            reservation.ReservationStatus = (int)ReservationStatus.Confirmed;
            db.Reservations.Add(reservation);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/ReservationsApi/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult DeleteReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservations.Remove(reservation);
            db.SaveChanges();

            return Ok(reservation);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(int id)
        {
            return db.Reservations.Count(e => e.ReservationId == id) > 0;
        }
    }
}