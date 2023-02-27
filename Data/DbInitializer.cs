using BookingSystem.Models;
using System;
using System.Linq;

namespace BookingSystem.Data
{
    public class DbInitializer
    {
        public static void Initialize(BookingDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Rooms.Any())
            {
                return;
            }

            var Rooms = new RoomModel[]
            {
            new RoomModel{Name="Conference Room A"},
            new RoomModel{Name="Conference Room B"},
            new RoomModel{Name="Conference Room C"},
            };
            foreach (RoomModel r in Rooms)
            {
                context.Rooms.Add(r);
            }
            context.SaveChanges();


            if (context.Hours.Any())
            {
                return;
            }
            var Hours = new HourModel[]
            {
            new HourModel{Hour="09"},
            new HourModel{Hour="10"},
            new HourModel{Hour="11"},
            new HourModel{Hour="12"},
            new HourModel{Hour="14"},
            new HourModel{Hour="15"},
            new HourModel{Hour="16"},
            new HourModel{Hour="17"},
            };
            foreach (HourModel h in Hours)
            {
                context.Hours.Add(h);
            }
            context.SaveChanges();

            if (context.Mins.Any())
            {
                return;
            }
            var Mins = new MinModel[]
            {
            new MinModel{Min="00"},
            new MinModel{Min="15"},
            new MinModel{Min="30"},
            new MinModel{Min="45"},
            };
            foreach (MinModel m in Mins)
            {
                context.Mins.Add(m);
            }
            context.SaveChanges();
        }
    }
}