namespace Articles.API.Dtos
{
    public class LoginResponseDto
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public DateTime Expiration {  get; set; }
    }
}
