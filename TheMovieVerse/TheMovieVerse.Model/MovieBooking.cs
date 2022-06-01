using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.Model
{
    public class MovieBooking
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(50)]
        public string FirstName{ get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int Age { get; set; }
        
    }
}
