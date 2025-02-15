﻿using AuthJWTCookie.Services.UserAPI.Cryptography.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AuthJWTCookie.Services.UserAPI.Helpers
{
    public class PasswordHasher: IPasswordHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        
    }
}
