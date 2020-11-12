﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NetCore.Fundamentals.Security.Data
{
    public static class StringExtensions
    {
        public static string Sha256(this string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}