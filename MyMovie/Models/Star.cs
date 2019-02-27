using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovie.Models
{
    public class Star
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}