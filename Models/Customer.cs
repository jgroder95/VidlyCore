using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidlyCore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        [ForeignKey("MembershipTypeId")]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
        
    }
}
