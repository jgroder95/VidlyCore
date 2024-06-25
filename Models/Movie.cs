using System.ComponentModel.DataAnnotations;

namespace VidlyCore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid date")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Please enter a valid date")]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Number of movies in stock")]
        [Range(1, 20)]
        public int NumberOfMoviesInStock { get; set; }
    }
}
