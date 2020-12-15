using System;
using ClearPost.Areas.Identity.Data;
using ClearPost.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ClearPost.Areas.Identity.IdentityHostingStartup))]
namespace ClearPost.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ClearPostContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ClearPostContextConnection")));

                services.AddDefaultIdentity<ClearPostUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                }).AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ClearPostContext>();
            });
        }
    }
}