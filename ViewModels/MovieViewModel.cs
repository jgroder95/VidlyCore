using VidlyCore.Models;

namespace VidlyCore.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<GenreType> GenreType { get; set; }

        public string Title
        {
            get
            {
                if (Movie.Id == 0)
                {
                    return "New Movie";
                }
                return "Edit Movie";
            }

        }
    }
}
