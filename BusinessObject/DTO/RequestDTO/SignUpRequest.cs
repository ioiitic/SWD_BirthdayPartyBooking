using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTO.RequestDTO
{
    public class SignUpRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        [Range(1, 2)]
        public int? Role { get; set; }
    }
}
