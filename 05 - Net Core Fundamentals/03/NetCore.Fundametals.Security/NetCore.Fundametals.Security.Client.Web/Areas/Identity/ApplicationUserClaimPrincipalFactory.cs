﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetCore.Fundamentals.Security.Client.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.Security.Client.Web.Areas.Identity
{
    public class ApplicationUserClaimPrincipalFactory:UserClaimsPrincipalFactory<ApplicationUser,IdentityRole>
    {
        public ApplicationUserClaimPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options
            ):base(userManager,roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("CareerStartedDate", user.CareerStartedDate.ToShortDateString()));
            identity.AddClaim(new Claim("FullName", user.FullName));

            return identity;
        }
    }
}
