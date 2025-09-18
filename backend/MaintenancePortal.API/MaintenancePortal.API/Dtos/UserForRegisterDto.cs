using System.ComponentModel.DataAnnotations;

namespace MaintenancePortal.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 20 characters.")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

