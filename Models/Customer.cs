using System.ComponentModel.DataAnnotations;

namespace VidlyCore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}
