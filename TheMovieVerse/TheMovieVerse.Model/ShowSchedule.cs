using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.Model
{
    public class ShowSchedule
    {
        [Key]
        [Required]
        public long Id { get; set; }

        public double TicketPrice { get; set; }

        [MaxLength(50)]
        public string ShowDate { get; set; }


        [MaxLength(50)]
        public string TimeSlot { get; set; }


        

        //public List<MovieBooking> MovieBookings { get; set; } = new List<MovieBooking>();
       
    }
}
