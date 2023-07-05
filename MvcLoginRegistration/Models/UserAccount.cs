
using System.ComponentModel.DataAnnotations;

namespace MvcLoginRegistration.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage =" First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = " Email is required.")]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$") ]
        public string Email { get; set; }


        [Required(ErrorMessage = " Username is required ")]
        public string UserName { get; set; }


        [Required(ErrorMessage = " Password is required. ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
