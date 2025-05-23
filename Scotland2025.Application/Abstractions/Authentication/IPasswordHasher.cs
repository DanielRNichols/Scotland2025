﻿namespace Scotland2025.Application.Abstractions.Authentication;

public interface IPasswordHasher
{
    string ComputeHash(string password, string salt);
    string ComputeHash(string password, string salt, string pepper, int iteration);
    string GenerateSalt();
}