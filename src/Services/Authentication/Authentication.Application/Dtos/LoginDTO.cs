﻿namespace AuthService.Application.DTOs
{
    public record LoginDTO
    {
        public string Email { get; set; } 
        public string Password { get; set; } 
    }
}
