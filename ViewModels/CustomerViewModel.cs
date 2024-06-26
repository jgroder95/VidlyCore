using VidlyCore.Models;
namespace VidlyCore.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipType { get; set; }

        public string Title
        {
            get
            {
                if (Customer.Id == 0)
                {
                    return "New Customer";
                }
                return "Edit Customer";
            }

        }
    }
}
