using LmycWeb.Data;
using LmycWeb.Models.Boat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.DummyData
{
    public class BoatDummyData
    {
        public static void SeedBoats(ApplicationDbContext context)
        {

            Boat boatOne = new Boat()
            {
                BoatName = "OceanPearl",
                LengthInFeet = 22,
                Year = 1987,
                Make = "Yamaha",
                RecordCreationDate = new DateTime(2013, 10, 5)
            };

            Boat boatWo = new Boat()
            {
                BoatName = "USS Saratoga",
                LengthInFeet = 56,
                Year = 1998,
                RecordCreationDate = new DateTime(2011, 3, 4)
            };

            if (!context.Boat.Any())
            {
                context.Boat.Add(boatOne);
                context.Boat.Add(boatWo);
            }

            context.SaveChanges();
        }
    }
}
