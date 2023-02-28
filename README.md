# BookingSystem

## Introduction
  The project build with .NET 6.0.  
  Use ASP.NET Core MVC for frontend and backend.  
  Use Entity Framework Core for ORM to connect database.  
  Use SQL server for database.  

  Database tables define as below model:  
```
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
```

  Functions:
  * Register and login/logout.  
  * User token cookie will expire after 10 mins, user need to login again with any operation.  
  * Choose meeting room and date.  
  * Add/Check/Delete Booking.  
  * Blocked the time that already expired.  
  * Blocked the time that already booked by others.  
  * Show the user name who booked at that time.

## Run project
### 1. Setup database
  Use docker compose file to build up SQL server engine or build up your SQL server engine with below config.  
```
Server name: localhost,
Login: sa,
Password: example_123,
Port: 1433
```
  You also can edit the "ConnectionStrings" in project's appsetting.json file to match your SQL server engine's setting.  

### 2. Run project
  Before you run the code, you need to migrate your database first.  
  Command at below.  
  
  .NET Core CLI:  
```
make migrate(no need to run when model do not have change):
dotnet ef migrations add CreateIdentitySchema --context ApplicationDbContext
dotnet ef migrations add CreateBookingSchema --context CreateBookingSchema

migrations:
dotnet ef database update --context ApplicationDbContext
dotnet ef database update --context CreateBookingSchema
```

  Visual Studio NuGet CLI:  
```
make migrate(no need to run when model do not have change):
$ Add-Migration CreateIdentitySchema -Context ApplicationDbContext
$ Add-Migration CreateBookingSchema -Context BookingDbContext

migrations:
$ Update-Database -Context ApplicationDbContext
$ Update-Database -Context BookingDbContext
```

  And then, you can run the project now.  
  
### 3. Operation
  First, you need to register a account.  
  
  Then, click the "Booking" on the top to enter booking page. Choose the meeting room and date, the system will auto show the timesheet at below. Click the blank on timesheet and submit it for add booking.  
  
  The "MyBooking" on the top is for user check their booking, user also can click the delete button to delete the booking.
