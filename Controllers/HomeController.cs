using BookingSystem.Data;
using BookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace BookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookingDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, BookingDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Booking()
        {
            string UserName = User.FindFirstValue(ClaimTypes.Name);
            ViewBag.UserName = UserName;
            BookingViewModel BookingViewModel = new BookingViewModel()
            {
                BookingList = _dbContext.Bookings.ToList(),
                RoomList = _dbContext.Rooms.ToList(),
                HourList = _dbContext.Hours.ToList(),
                MinList = _dbContext.Mins.ToList(),
            };
            return View(BookingViewModel);
        }

        [Authorize]
        public IActionResult MyBooking()
        {
            string UserName = User.FindFirstValue(ClaimTypes.Name);
            ViewBag.UserName = UserName;
            BookingViewModel BookingViewModel = new BookingViewModel()
            {
                BookingList = _dbContext.Bookings.ToList(),
                RoomList = _dbContext.Rooms.ToList(),
                HourList = _dbContext.Hours.ToList(),
                MinList = _dbContext.Mins.ToList(),
            };
            return View(BookingViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBooking(AddBookingDto addBookingDto)
        {
            foreach (string time in addBookingDto.timeId)
            {
                int HourId = Int32.Parse(time[0].ToString());
                int MinId = Int32.Parse(time[1].ToString());

                if (_dbContext.Bookings.Where(x => x.Date == DateTime.Parse(addBookingDto.date) && x.Hour.Id == HourId && x.Min.Id == MinId).Any()) 
                {
                    return View("AddBookingFail");
                };

                BookingModel newBooking = new BookingModel()
                {
                    UserName = addBookingDto.userName,
                    Room = _dbContext.Rooms.Where(x => x.Id == addBookingDto.roomId).First(),
                    Date = DateTime.Parse(addBookingDto.date),
                    Hour = _dbContext.Hours.Where(x => x.Id == HourId).First(),
                    Min = _dbContext.Mins.Where(x => x.Id == MinId).First()
                };
                _dbContext.Bookings.Add(newBooking);
            }
            _dbContext.SaveChanges();
            return View();
        }

        [Authorize]
        public void DeleteBooking(int id)
        {
            try
            {
                var deleteRecord = _dbContext.Bookings.Where(x => x.Id == id).First();
                _dbContext.Bookings.Remove(deleteRecord);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError("Delete booking with Id: " + id + " fail");
                _logger.LogError("Erroe msg: " + e);
            }
        }
    }
}