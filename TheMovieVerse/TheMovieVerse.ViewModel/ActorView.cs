using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class ActorView
    {
        //public ActorView()
        //{
        //    this.MovieActors = new HashSet<MovieActorView>();
        //}

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public string Age { get; set; }

        // public virtual ICollection<MovieActorView> MovieActors { get; set; }
    }
}
