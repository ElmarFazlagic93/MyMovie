using System.ComponentModel.DataAnnotations;

namespace MyMovie.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public int RateNumber { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}