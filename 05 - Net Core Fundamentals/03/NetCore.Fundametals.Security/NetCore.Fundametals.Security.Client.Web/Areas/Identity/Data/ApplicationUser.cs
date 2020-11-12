﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.Security.Client.Web.Models
{
    public class ApplicationUser:IdentityUser
    {
        public DateTime CareerStartedDate { get; set; }
        public string FullName { get; set; }
    }
}