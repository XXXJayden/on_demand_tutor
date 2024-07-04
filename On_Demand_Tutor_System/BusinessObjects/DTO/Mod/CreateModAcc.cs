using BusinessObjects.Enums.User;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTO.Mod
{
    public class CreateModAcc
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must enter your name")]
        public string FullName { get; set; }

        public string Status = UserStatus.Active;
    }
}
