using System;
using LoginFormMVC.Areas.Identity.Data;
using LoginFormMVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LoginFormMVC.Areas.Identity.IdentityHostingStartup))]
namespace LoginFormMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginFormMVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LoginFormMVCContextConnection")));

                services.AddDefaultIdentity<LoginFormMVCUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LoginFormMVCContext>();
            });
        }
    }
}