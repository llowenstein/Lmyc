using LmycWeb.Data;
using LmycWeb.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.DummyData
{
    public class ReservationDummyData
    {
        public static void SeedReservations(ApplicationDbContext context)
        {

            Reservation resOne = new Reservation()
            {
                StartTime = new DateTime(2017, 6, 10),
                EndTime = new DateTime(2017, 6, 12),
            };

            Reservation resTwo = new Reservation()
            {
                StartTime = new DateTime(2018, 4, 1),
                EndTime = new DateTime(2018, 4, 2),
            };

            if (!context.Reservations.Any())
            {
                context.Reservations.Add(resOne);
                context.Reservations.Add(resTwo);
            }

            context.SaveChanges();
        }
    }
}
