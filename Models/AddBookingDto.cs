namespace BookingSystem.Models
{
    public class AddBookingDto
    {
        public string userName { get; set; }
        public int roomId { get; set; }
        public string date { get; set; }
        public List<string > timeId { get; set; }
    }
}
