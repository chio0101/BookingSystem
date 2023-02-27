using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }

        public string? UserName { get; set; }

        [Required(ErrorMessage = "The Room field is required.")]
        public RoomModel Room { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Hour field is required.")]
        public HourModel Hour { get; set; }

        [Required(ErrorMessage = "The Min field is required.")]
        public MinModel Min { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class RoomModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Name { get; set; }
    }

    public class HourModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Hour field is required.")]
        [StringLength(3, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Hour { get; set; }
    }

    public class MinModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Min field is required.")]
        [StringLength(3, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Min { get; set; }
    }
}
