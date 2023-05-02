using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketFunctionApp
{
  public class Bookings
  {


    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? TheatreName { get; set; }
    public string? MovieName { get; set; }
    public DateTime BookingDate { get; set; }
    public int? SeatNumber { get; set; }
    public bool BookingStatus { get; set; }


  }
}



