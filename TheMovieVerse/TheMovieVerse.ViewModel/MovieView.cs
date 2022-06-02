using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class MovieView
    {

        [MaxLength(150)]
        public string MovieTitle { get; set; }

        public List<ActorView> Actors { get; set; } = new List<ActorView>();

        [MaxLength(50)]
        public string MovieDirector { get; set; }

        [MaxLength(50)]
        public string MovieProducer { get; set; }

        [MaxLength(50)]
        public string MovieLanguage { get; set; }

        [MaxLength(50)]
        public string MovieGenre { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string MovieRating { get; set; }

        public bool IsUpcoming { get; set; }

        public string MovieDuration { get; set; }
        public List<ShowScheduleView> ShowSchedules { get; set; } = new List<ShowScheduleView>();

       // public List<MovieBookingView> MovieBookings { get; set; } = new List<MovieBookingView>();
    }
}

