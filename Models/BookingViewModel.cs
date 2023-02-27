namespace BookingSystem.Models
{
    public class BookingViewModel
    {
        public List<BookingModel> BookingList { get; set; } = new List<BookingModel>();
        public List<RoomModel> RoomList { get; set; } = new List<RoomModel>();
        public List<HourModel> HourList { get; set; } = new List<HourModel>();
        public List<MinModel> MinList { get; set; } = new List<MinModel>();

    }
}
