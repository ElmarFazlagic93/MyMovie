using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string Image { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }

        public int ShowTypeId { get; set; }
        public virtual ShowType ShowType { get; set; }

        [JsonIgnore]
        [NotMapped]
        public double AverageRating { set; get; }
    }
}
