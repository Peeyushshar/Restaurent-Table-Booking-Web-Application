using System.ComponentModel.DataAnnotations;

namespace Restaurant_Table_Booking.Application.DTOs.AuthDto.RequestDtos
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
