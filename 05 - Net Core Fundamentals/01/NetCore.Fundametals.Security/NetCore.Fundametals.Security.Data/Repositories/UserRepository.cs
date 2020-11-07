﻿using NetCore.Fundamentals.Security.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Fundamentals.Security.Data.Repositories
{
    public class UserRepository :  IUserRepository
    {
        private List<User> users = new List<User> {
            new User
            {
                Id=3522,
                Name = "erick",
                Password = "oPMoWwfCbA3NIZFEfzkRcNBgNejVfjGgSLqHB086mhU=",
                FavoriteColor = "blue",
                Role = "Admin",
                GoogleId = "102958934873274895259"
            }
        };

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = users.SingleOrDefault(u => u.Name == username && u.Password == password.Sha256());

            return user;
        }

        public User GetByGoogleId(string googleId)
        {
            var user = users.SingleOrDefault(u => u.GoogleId == googleId);
            return user;
        }
    }
}
