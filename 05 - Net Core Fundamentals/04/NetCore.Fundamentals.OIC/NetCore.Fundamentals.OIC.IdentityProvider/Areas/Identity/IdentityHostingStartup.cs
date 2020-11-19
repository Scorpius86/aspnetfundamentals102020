using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Fundamentals.OIC.IdentityProvider.Areas.Identity.Data;
using NetCore.Fundamentals.OIC.IdentityProvider.Data;

[assembly: HostingStartup(typeof(NetCore.Fundamentals.OIC.IdentityProvider.Areas.Identity.IdentityHostingStartup))]
namespace NetCore.Fundamentals.OIC.IdentityProvider.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityProviderContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityProviderContextConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityProviderContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                    ApplicationUserClaimsPrincipalFactory>();
                services.AddTransient<IEmailSender, EmailSender>();

                services.AddAuthentication()
                    .AddGoogle(opt =>
                    {
                        opt.ClientId = context.Configuration["Google:ClientId"];
                        opt.ClientSecret = context.Configuration["Google:ClientSecret"];
                    });
            });
        }
    }
}