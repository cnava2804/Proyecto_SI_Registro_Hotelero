using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_SI_Registro_Hotelero.Areas.Identity.Data;
using Proyecto_SI_Registro_Hotelero.Data;

[assembly: HostingStartup(typeof(Proyecto_SI_Registro_Hotelero.Areas.Identity.IdentityHostingStartup))]
namespace Proyecto_SI_Registro_Hotelero.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PRHoteleroDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PRHoteleroDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<PRHoteleroDbContext>();
            });
        }
    }
}