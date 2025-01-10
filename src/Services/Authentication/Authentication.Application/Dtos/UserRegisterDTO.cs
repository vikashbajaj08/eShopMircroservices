﻿namespace AuthService.Application.DTOs
{
    public record UserRegisterDTO
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } =default!;
        public string PhoneNumber { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
