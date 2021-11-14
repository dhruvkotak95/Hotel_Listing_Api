using Microsoft.AspNetCore.Identity;

namespace Hotel_Listing_Api.DataModel
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
