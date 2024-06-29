using Microsoft.EntityFrameworkCore;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Business;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Models;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Repository;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.RazorWebApp.Pages.MessageHub;

namespace NET1704_221_ASM3_SE170224_NguyenTruongThinh.RazorWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR(); // Add this line to enable SignalR

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor(); // Add this line to enable Blazor Server
            builder.Services.AddDbContext<ASM3_221_SE170224Context>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(GenericRepository<>));
            builder.Services.AddScoped<TicketRepository>();
            builder.Services.AddScoped<TicketBusiness>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapHub<TicketHub>("/ticketHub"); // Ensure this is mapped correctly

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
