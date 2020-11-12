using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Fundamentals.Security.Client.Web.Data;
using NetCore.Fundamentals.Security.Client.Web.Models;

[assembly: HostingStartup(typeof(NetCore.Fundamentals.Security.Client.Web.Areas.Identity.IdentityHostingStartup))]
namespace NetCore.Fundamentals.Security.Client.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NetCoreFundamentalsSecurityClientWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NetCoreFundamentalsSecurityClientWebContextConnection")));

                services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<NetCoreFundamentalsSecurityClientWebContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimPrincipalFactory>();
                services.AddTransient<IEmailSender, EmailSender>();

            });
        }
    }
}