﻿using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //relations

        public ICollection<ActorMovie>? ActorMovies { get; set; }
    }
}
