namespace AuthService.Application.DTOs
{
    public record UserDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string[] Roles { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
