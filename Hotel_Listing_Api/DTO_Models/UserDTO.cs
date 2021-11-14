using System.ComponentModel.DataAnnotations;

namespace Hotel_Listing_Api.DTO_Models
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        //[StringLength(15, ErrorMessage = "Password must be in range from {2} to {1}", MinimumLength = 8 )]
        [MinLength(8)]
        [MaxLength(15)]
        public string Password { get; set; }
    }

    public class UserDTO : LoginDTO
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
