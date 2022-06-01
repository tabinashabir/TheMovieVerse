using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class ShowScheduleView
    {
        public double TicketPrice { get; set; }

        [MaxLength(50)]
        public string ShowDate { get; set; }
        [MaxLength(50)]
        public string TimeSlot { get; set; }

       // public List<MovieBookingView> MovieBookings { get; set; } = new List<MovieBookingView>();
    }
}
