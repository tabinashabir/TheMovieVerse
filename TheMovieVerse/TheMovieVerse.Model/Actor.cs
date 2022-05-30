using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.Model
{
    public class Actor
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
