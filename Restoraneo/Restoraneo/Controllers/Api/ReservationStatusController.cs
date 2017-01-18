using Restoraneo.Dtos;
using Restoraneo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Restoraneo.Controllers.Api
{
    [Authorize]
    public class ReservationStatusController : ApiController
    {
        private ApplicationDbContext _context;

        public ReservationStatusController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult ChangeReservationStatus(ReservationStatusDto dto)
        {
            int reservationId = int.Parse(dto.id);
            int reservationStatusId = int.Parse(dto.statusId);
            var reservation = _context.Reservations.Where(r => r.ReservationId == reservationId).SingleOrDefault();
            reservation.ReservationStatus = reservationStatusId;
            _context.SaveChanges();

            return Ok();
        }

    }
}
