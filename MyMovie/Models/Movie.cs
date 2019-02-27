using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovie.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }
    }
}
