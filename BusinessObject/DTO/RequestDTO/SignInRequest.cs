using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTO.RequestDTO
{
    public class SignInRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }  
    }
}
